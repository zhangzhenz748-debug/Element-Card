using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class Select : MonoBehaviour//卡牌选择
{
    public int date;//卡牌的可选数量
    public GameObject game;//卡牌预制体
    public GameObject Object;
    public Transform transform1;//手牌
    public Transform transform2;//弃牌
    public ObjectPool<GameObject> pool;
    public List<GameObject> games;//归还卡牌列表
    public List<CardData> CardList;//属性列表
    void Start()
    {
        pool = new ObjectPool<GameObject>(CreateGame, GetGame, RelaseGame, DestroyGame);
        EventCenter.Instance.AddEvent<string>("选中卡牌",C);//选择卡牌的信号
        EventCenter.Instance.AddEvent("胜利",A);
        //A();
    }
    void C(string name)
    {
        //向牌组里添加卡牌
        EventCenter.Instance.EventTrigger<string>("添加卡牌",name);
        Debug.Log($"Select{name}");
        B();
        Object.SetActive(false);
    }
    //随机加入卡牌
    public void A()
    {
        Object.SetActive(true);
        int max=CardManager.Cardmanager.cardDatas.Length;
        for(int i=0;i<date;i++)
        {
            CardList.Add(CardManager.Cardmanager.cardData(Random.Range(0,max)));
            GameObject game = pool.Get();
            Card card = game.GetComponent<Card>();
            card.InitCard(CardList[i]);
            // string name=CardList[i].cardName;//添加卡牌功能

            // var m=CardPlant.Plant(name);
            // card.cost=m.Item1;
            // card.action=m.Item2;
            // card.MyImage(card.action.image);
            //CardPlant.Plant(name);
            games.Add(game);
        }
    }
    public void B()
    {
        //归还数据
        foreach(var a in games)
        {
            pool.Release(a);
        }
        CardList.Clear();//清除数据
        games.Clear();
    }
    //要使用对象池添加可选卡牌
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
}
