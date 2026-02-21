using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bout : MonoBehaviour//回合机制
{
    public GameObject game;
    //玩家回合(当玩家按下结束当前回合按钮就进入敌人回合)
    public void player()
    {
        game.SetActive(false);
        //回收卡牌--这个是将我当前的手牌都进入弃牌区
        HandPool.Handpool.RelseCard();
        //回收护盾值
        enemy();
    }
    //敌人回合(敌人打完就进入玩家回合)可以在敌人回合的时候提前洗好牌
    public void enemy()
    {
        Debug.Log("敌人回合");
        //执行敌人逻辑
        
        //敌人执行完逻辑
        game.SetActive(true);
        //开始发牌
        HandPool.Handpool.CardPool(10);
    }
    //判断胜利
}
