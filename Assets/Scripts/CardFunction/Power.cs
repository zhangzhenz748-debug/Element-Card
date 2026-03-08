using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "增加能量", menuName = "ScriptableObjects/增加能量", order = 3)]
public class Power : ICardEffect
{
    public override void Excute(AbstractGameAction action)
    {
        eneray._eneray.SetEneray(action.harm);
    }
}
