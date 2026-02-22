using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour//敌人管理器
{
    int data;
    //获取子物体
    void A()
    {
        data = transform.childCount;//获取所有敌人
    }
    void B()
    {
        for(int i=1;i<=data;i++)
        {
            Monster m=transform.GetChild(i).GetComponent<Monster>();
            if(m.blood<=0)
            {
                
            }
        }
    }
}
