using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Attack_1", menuName = "ScriptableObjects/Attack_1", order = 1)]
public class Attack_1 :AttackInterface
{
    int data;//攻击力
    public override void Attack()
    {
        Debug.Log("攻击玩家");
    }
}
