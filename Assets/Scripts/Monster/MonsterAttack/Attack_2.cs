using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Attack_2", menuName = "AttackInterface/Attack_2", order = 1)]
public class Attack_2 :AttackInterface
{
    public int data=7;//攻击力
    public override void Attack()
    {
        //加入攻击列表
        
        Debug.Log("攻击玩家");
    }
}
