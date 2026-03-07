using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] 
public class CardData
{
    public string cardName;   // 卡牌名称
    public Sprite cardImage;  // 卡牌图片
    [SerializeReference]
    public ICardEffect cardEffect;//卡牌功能
    public TargetingMode targeting;//卡牌触发类型
    public int power;         // 你甚至可以顺便加个数值
    public int Eneray;//消耗能量
}
public class CardManager : MonoBehaviour//卡牌资源类
{
    public CardData[] cardDatas;
    public static CardManager Cardmanager{get;private set;}
    void Awake()
    {
        if(Cardmanager!=null&&Cardmanager!=this)
        {
            Destroy(gameObject);
            return;
        }
        Cardmanager=this;
    }
    public CardData CardData(string name)//查找素材
    {
        foreach(var a in cardDatas)
        {
            if(a.cardName==name)
            {
                return a;
            }
        }
        return null;
    }
    public CardData cardData(int i)
    {
        if(cardDatas.Length<i)
        return null;
        return cardDatas[i];
    }
}
