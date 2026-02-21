using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Monster : MonoBehaviour,IDropHandler//生物类
{
    //护盾
    public int shield;
    //血量
    public int blood;//当前生命值
    public int Maxblood;//最大生命值
    public Slider slider;
    private Animator animator;
    void Start()
    {
        animator=GetComponent<Animator>();
        Maxblood=100;
        blood=Maxblood;
        shield=9;
    }
    //攻击力
    public virtual void OnDrop(PointerEventData eventData)
    {
        GameObject cardObject = eventData.pointerDrag;
        Card cardDecorator=cardObject.GetComponent<Card>();
        if(cardDecorator!=null)
        {
            cardDecorator.action.Targets.Add(this);//给卡牌添加攻击目标
            cardDecorator.Excute();
            //调用被攻击效果
            B();//扣血
        }
        print("有东西被托到我身上");//IDropHandler
    }
    public void B()
    {
        //调用动画状态机
        animator.SetInteger("M",1);//被攻击
        slider.value=(float)blood/(float)Maxblood;
        A();
    }
    //死亡
    public void A()
    {
        if(blood<=0)
        {
            //归还给对象池
            animator.SetInteger("M",3);//死亡
        }
    }
    public void C()
    {
        //调用动画状态机
        animator.SetInteger("M",2);//攻击
    }
    public void D()//!!!!
    {
        //调用动画状态机
        animator.SetInteger("M",0);//默认
    }
    public void Onblood()
    {
        Debug.Log($"当前血量{blood},护盾{shield}");
    }

}
