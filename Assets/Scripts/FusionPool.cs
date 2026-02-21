using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusionPool : MonoBehaviour//融合工厂
{
    public static (ICardEffect, AbstractGameAction) Plant(string Cardname1,string Cardname2)
    {
        AbstractGameAction action;
        switch ((Cardname1,Cardname2))
        {
            case ("",""):
                action = new AbstractGameAction();
                action.harm = 0;
                action.name = "斩击";
                action.image = CardManager.Cardmanager.Cardimage(Cardname1);
                return (new BasicsAttack(), action);
        }
        return (null, null);
    }
}
