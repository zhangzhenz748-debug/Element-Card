using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ICardEffect : ScriptableObject 
{
    public abstract void Excute(AbstractGameAction action);
}
