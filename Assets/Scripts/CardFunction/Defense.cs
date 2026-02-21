using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : ICardEffect//护盾
{
    public void Excute(AbstractGameAction action)
    {
        action.Source.shield+=action.harm;//加护盾
    }
}