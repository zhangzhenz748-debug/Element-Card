using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Card : MonoBehaviour//卡牌类
{
    public ICardEffect cost;//卡牌功能
    public AbstractGameAction action;//属性
    public Image image;//图片
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
    }
    public void Excute()//执行卡牌功能
    {
        cost.Excute(action);
        //卡牌进入弃牌区--这个是出牌后进入弃牌区
        HandPool.Handpool.Fold(this);
        //清除数据
        action.Clase();
        //排序
        EventCenter.Instance.EventTrigger("卡牌排序");
    }
}