using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class Monster : MonoBehaviour, IDropHandler//生物类
{
    //护盾
    public int shield;
    //血量
    public int blood;//当前生命值
    public int Maxblood;//最大生命值
    public int date;//攻击力
    public Slider slider;
    public Text text;
    //public List<>
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        blood = Maxblood;
        EventCenter.Instance.AddEvent("攻击玩家", Exed);
    }
    //攻击力
    public virtual void OnDrop(PointerEventData eventData)//将自己添加给卡牌
    {
        //给卡牌添加攻击目标
        GameObject cardObject = eventData.pointerDrag;
        Card card = cardObject.GetComponent<Card>();
        if (card != null)
        {
            //card.Excute(this);
        }
        //调用被攻击效果
        B();//扣血
        print("有东西被托到我身上");//IDropHandler
    }
    public virtual void Exed()//攻击逻辑
    {
        C();
    }
    public void B()
    {
        //调用动画状态机
        animator.SetInteger("M", 1);//被攻击
        slider.value = (float)blood / (float)Maxblood;
        text.text = blood.ToString();
        A();
    }
    //死亡
    public void A()
    {
        if (blood <= 0)
        {
            //归还给对象池
            animator.SetInteger("M", 3);//死亡 
            EventCenter.Instance.EventTrigger("怪物死亡");
        }
    }
    public void C()
    {
        //调用动画状态机
        animator.SetInteger("M", 2);//攻击
    }
    public void D()//!!!!
    {
        //调用动画状态机
        animator.SetInteger("M", 0);//默认
    }
    public void Onblood()
    {
        Debug.Log($"当前血量{blood},护盾{shield}");
    }
}
