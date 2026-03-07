using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class HandPool : MonoBehaviour//卡牌管理类
{
    //统计牌组
    public GameObject game;//卡牌预制体
    public Transform transform1;//手牌
    public Transform transform2;//弃牌
    public int SCard = 0;//初始发牌数量
    public List<string> StartCardList;
    public static HandPool Handpool { get; private set; }//单例
    public ObjectPool<GameObject> pool;//对象池--这个对象池好像存储了我所有的卡牌
    private List<CardData> HandDate;//目前卡组
    private List<CardData> fold;//弃牌组
    private List<CardData> AMD;//手牌组
    private List<GameObject> AMDgame;//归还列表
    private List<CardData> Fapai;//发牌组
    public void FaPai()
    {
        Fapai = new List<CardData>(HandDate);//拷贝一份
    }
    void Awake()
    {
        if (Handpool != null && Handpool != this)
        {
            Destroy(gameObject);
        }
        Handpool = this;

        EventCenter.Instance.AddEvent<string>("添加卡牌", AddList);
        //EventCenter.Instance.AddEvent("添加卡牌", BattleStartInit);
        pool = new ObjectPool<GameObject>(CreateGame, GetGame, RelaseGame, DestroyGame);
        HandDate = new List<CardData>();
        fold = new List<CardData>();
        AMD = new List<CardData>();
        AMDgame = new List<GameObject>();
        Fapai = new List<CardData>();
        EventCenter.Instance.AddEvent<int>("发牌", CardPool);
    }
    void Start()
    {
        //StartCardList=new List<string>();
        //配置基础卡组                
        //Hand(HandDate);
        StartCard();
        Fisher(Fapai);//洗牌
        //CardPool(3);//创建5张牌
    }
    public void AddList(string name)//添加卡牌到卡组
    {
        AddCard(name);
        RelseCard();
        BattleStartInit();
        //StartCard();
    }
    public void BattleStartInit()
    {
        Debug.Log($"[监控] 开始拷贝前，HandDate 数量: {HandDate.Count}");
        // 1. 清空上一场的残留
        Fapai.Clear();
        fold.Clear();
        AMD.Clear();
        // 2. 从全局大牌库（HandDate）深拷贝一份到当前的抽牌堆
        Fapai = new List<CardData>(HandDate);
        Debug.Log($"[监控] 拷贝完成后，Fapai 数量: {Fapai.Count}");
        // 3. 洗牌
        Fisher(Fapai);
        // 4. 初始抽牌
        CardPool(SCard);
    }
    public void AddCard(string name)//添加单个卡牌
    {
        HandDate.Add(CardManager.Cardmanager.CardData(name));
        //FaPai();
        Debug.Log($"Handpool{name}");
    }
    void StartCard()
    {
        foreach (string i in StartCardList)
        {
            AddCard(i);
        }
        BattleStartInit();
    }
    void Hand(List<CardData> ts)//创建卡牌
    {
        foreach (var a in CardManager.Cardmanager.cardDatas)
        {
            ts.Add(a);
        }
    }
    public GameObject CreateGame()
    {
        var obj = Instantiate(game);//实例化
        return obj;
    }
    public void GetGame(GameObject game)
    {
        //切换父对象
        game.transform.SetParent(transform1, false);
        game.SetActive(true);
        Card card = game.GetComponent<Card>();
        if (card != null)
        {
            // 如果你使用了 CanvasGroup 控制拖拽，记得重置
            if (card.GetComponent<CanvasGroup>())
                card.GetComponent<CanvasGroup>().blocksRaycasts = true;
            // 确保 Image 开启了射线检测
            if (card.image != null) card.image.raycastTarget = true;
        }
    }
    public void RelaseGame(GameObject game)
    {
        //切换父对象
        game.transform.SetParent(transform2, false);
        game.SetActive(false);
    }
    public void DestroyGame(GameObject game)
    {
        Destroy(game);
    }
    //弃牌牌组
    public void Fold(Card game)//打出卡牌就添加到这里
    {
        CardData cardData = game.baseData;
        GameObject gameObject = game.gameObject;
        // 安全检查：如果已经在 AMD 列表里，先移除
        if (AMD.Contains(cardData))
        {
            AMD.Remove(cardData);
        }
        fold.Add(cardData);
        if (AMDgame.Contains(gameObject))
        {
            AMDgame.Remove(gameObject);
            pool.Release(gameObject);//还数据
        }
    }
    //发牌
    public void CardPool(int x)
    {
        //洗牌逻辑
        Fisher(Fapai);
        for (int i = 0; i < x; i++)
        {
            Pool(i);
        }
    }
    public void Pool(int i)//创建卡牌
    {
        //从对象池里拿出一个对象
        GameObject game = pool.Get();
        AMDgame.Add(game);
        //给这个卡牌附加能力(用列表)
        Card card = game.GetComponent<Card>();
        //检查HandDate是否为空
        if (Fapai.Count == 0)
        {
            //如果为空就把弃牌组的拿过来
            if (fold.Count != 0)
            {
                Fapai.AddRange(fold);
            }
            // 同样要清空弃牌堆
            fold.Clear();
            Fisher(Fapai);//洗牌
        }
        if (Fapai.Count > 0)
        {
            card.InitCard(Fapai[0]);
            AMD.Add(Fapai[0]);//添加到手牌组
            Fapai.RemoveAt(0);
            //排序
            EventCenter.Instance.EventTrigger("卡牌排序");
        }
    }
    //回收卡牌
    public void RelseCard()
    {
        foreach (var a in AMD)
        {
            //添加到弃牌组
            fold.Add(a);
            //归还对象
        }
        foreach (var a in AMDgame)
        {
            pool.Release(a);
        }
        AMDgame.Clear();
        AMD.Clear();//清除
    }
    //洗牌算法
    public void Fisher<T>(List<T> values)
    {
        int Len = values.Count - 1;
        int i;
        for (int j = Len; j > 0; j--)
        {
            i = Random.Range(0, j + 1);
            var tem = values[i];
            values[i] = values[j];
            values[j] = tem;
        }
    }
}