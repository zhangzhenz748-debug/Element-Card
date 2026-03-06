using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour//敌人管理器
{
    //应该加一个敌人类型池
    int data;//敌人数量
    void Start()
    {
        EventCenter.Instance.AddEvent("怪物死亡",B);
        data = transform.childCount;
        B();
    }
    //获取子物体
    void A()
    {
        data = transform.childCount;//获取所有敌人
    }
    void B()
    {
        int s=0;
        for(int i=0;i<data;i++)
        {
            Monster m=transform.GetChild(i).GetComponent<Monster>();
            if(m.blood<=0)
            {
                //死亡一个敌人
                s++;
                //回收这个敌人

            }
        }
        if(s==data)
        {
            //所有敌人死亡获得胜利
            EventCenter.Instance.EventTrigger("胜利");
        }
        Debug.Log($"胜利{s}{data}");
    }
    //创建敌人
    void C()
    {
        
    }
}
