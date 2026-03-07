using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Defense", menuName = "ScriptableObjects/Defense", order = 2)]
public class Defense : ICardEffect//护盾
{
    public override void Excute(AbstractGameAction action)
    {
        MonsterEvent Event=action.Caster.GetComponent<MonsterEvent>();
        Event.TriggerSignal<int>("护盾",action.harm);
    }
}