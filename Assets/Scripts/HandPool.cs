using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class HandPool : MonoBehaviour//卡牌管理类
{
    //统计牌组
    public GameObject game;//预制体
    public Transform transform1;
    public Transform transform2;
    public static HandPool Handpool { get; private set; }//单例
    public ObjectPool<GameObject> pool;//对象池--这个对象池好像存储了我所有的卡牌
    private List<(ICardEffect, AbstractGameAction)> HandDate;//目前卡组
    private List<(ICardEffect, AbstractGameAction)> fold;//弃牌组
    private List<(ICardEffect, AbstractGameAction)> AMD;//手牌组
    private List<GameObject> AMDgame;
    private List<(ICardEffect, AbstractGameAction)> Fapai;//发牌组
    public void FaPai()
    {
        Fapai = new List<(ICardEffect, AbstractGameAction)>(HandDate);//拷贝一份
    }
    void Awake()
    {
        if (Handpool != null && Handpool != this)
        {
            Destroy(gameObject);
        }
        Handpool = this;
    }
    void Start()
    {
        pool = new ObjectPool<GameObject>(CreateGame, GetGame, RelaseGame, DestroyGame);
        HandDate = new List<(ICardEffect, AbstractGameAction)>();
        fold = new List<(ICardEffect, AbstractGameAction)>();
        AMD = new List<(ICardEffect, AbstractGameAction)>();
        AMDgame=new List<GameObject>();
        //配置基础卡组                
        Hand(HandDate);
        FaPai();
        Fisher(Fapai);//洗牌
        CardPool(10);//创建5张牌
    }
    void Hand(List<(ICardEffect, AbstractGameAction)> ts)
    {
        foreach(var a in CardManager.Cardmanager.cardDatas)
        {
            ts.Add(CardPlant.Plant(a.cardName));
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
        ICardEffect cardEffect = game.cost;
        AbstractGameAction action = game.action;
        GameObject gameObject = game.gameObject;
        // 安全检查：如果已经在 AMD 列表里，先移除
        if (AMD.Contains((cardEffect, action)))
        {
            AMD.Remove((cardEffect, action));
        }
        fold.Add((cardEffect, action));
        AMDgame.Remove(gameObject);
        pool.Release(gameObject);//还数据
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
    public void Pool(int i)
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
            Fapai.AddRange(fold);
            // 同样要清空弃牌堆
            fold.Clear();
            Fisher(Fapai);
        }
        card.cost = Fapai[0].Item1;
        card.action = Fapai[0].Item2;
        Fapai.RemoveAt(0);
        card.MyImage(card.action.image);//设置图片
        AMD.Add((card.cost, card.action));//添加到手牌组
        //排序
        EventCenter.Instance.EventTrigger("卡牌排序");
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