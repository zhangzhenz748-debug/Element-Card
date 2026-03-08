using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "攻击", menuName = "ScriptableObjects/攻击", order = 1)]
public class BasicsAttack : ICardEffect//斩击
{//最基础的单次攻击类
    public int s;//攻击力
    public override void Excute(AbstractGameAction action)
    {
        MonsterEvent Event=action.Target.GetComponent<MonsterEvent>();
        Event.TriggerSignal<int>("攻击",-action.harm);
        Debug.Log("攻击");
    }
}
