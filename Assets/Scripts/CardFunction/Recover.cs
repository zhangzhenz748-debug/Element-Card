using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Recover", menuName = "ScriptableObjects/Recover", order = 3)]
public class Recover : ICardEffect//回血
{
    public override void Excute(AbstractGameAction action)
    {
        MonsterEvent Event=action.Caster.GetComponent<MonsterEvent>();
        Event.TriggerSignal<int>("回血",action.harm);
    }
}
