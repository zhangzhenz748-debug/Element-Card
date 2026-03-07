using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bout : MonoBehaviour//回合机制
{
    public GameObject game;
    public int StartCard = 5;
    public int Catd;
    void Start()
    {
        EventCenter.Instance.AddEvent<bool>("回合结束", Play);
    }
    //玩家回合(当玩家按下结束当前回合按钮就进入敌人回合)
    public void Play(bool shengl)
    {
        //播放回收动画
        //回收卡牌--这个是将我当前的手牌都进入弃牌区
        HandPool.Handpool.RelseCard();
        //回收护盾值
        if (shengl)
        {
            game.SetActive(false);
            StartCoroutine(A(shengl));
        }
    }
    public void player()
    {
        Play(true);
    }
    //敌人回合(敌人打完就进入玩家回合)可以在敌人回合的时候提前洗好牌
    public void enemy()
    {
        Debug.Log("敌人回合");
        //执行敌人逻辑
        EventCenter.Instance.EventTrigger("攻击玩家");
        //敌人执行完逻辑
        game.SetActive(true);
        //恢复能量
        eneray._eneray.Text();
        //开始发牌
        HandPool.Handpool.CardPool(StartCard);
    }
    public IEnumerator A(bool p)
    {
        yield return new WaitForSeconds(0.5f);
        enemy();
    }
}
