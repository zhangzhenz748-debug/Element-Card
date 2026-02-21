using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Card : MonoBehaviour//卡牌类
{
    public ICardEffect cost;
    public AbstractGameAction action;//属性
    public Image image;
    void Awake()
    {
        action = new AbstractGameAction();
        cost = new BasicsAttack();
        image = GetComponent<Image>();
    }
    void Start()
    {
        MyImage(action.image);
    }
    public void MyImage(Sprite sprite = null)
    {
        image.sprite = sprite;
        //image.SetNativeSize();
    }
    public void Excute()
    {
        cost.Excute(action);
        //卡牌进入弃牌区--这个是出牌后进入弃牌区
        HandPool.Handpool.Fold(this);
        //清除数据
        action.Clase();
        //排序
        CardLayout.Instance.CardPos();
    }
}