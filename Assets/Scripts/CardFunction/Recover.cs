using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover : ICardEffect
{
    public void Excute(AbstractGameAction action)
    {
        action.Source.blood+=action.harm;
    }
}
