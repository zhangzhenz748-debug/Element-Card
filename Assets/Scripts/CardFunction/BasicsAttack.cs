using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicsAttack : ICardEffect//斩击
{//最基础的单次攻击类
    public void Excute(AbstractGameAction action)
    {
        foreach(var i in action.Targets)
        {
            i.shield-=action.harm;
            if(i.shield<0)
            {
                i.blood+=i.shield;
                i.shield=0;
            }
        }
        Debug.Log("攻击");
    }
}
