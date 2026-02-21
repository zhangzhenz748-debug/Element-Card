using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class CardDecorator :ICardEffect//抽象装饰器
{
    ICardEffect cardEffect;
    CardDecorator(ICardEffect card)
    {
        cardEffect=card;
    }
    public virtual void Excute(AbstractGameAction action)
    {
        cardEffect.Excute(action);
    }
}
