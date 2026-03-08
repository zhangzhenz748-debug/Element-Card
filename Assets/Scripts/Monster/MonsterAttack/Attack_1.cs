using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Attack_1", menuName = "AttackInterface/Attack_1", order = 1)]
public class Attack_1 :AttackInterface
{
    public int data=7;//攻击力
    public MonsterTrait Caster;//发起者
    public MonsterTrait Target;//接受者
    public GameObject game;//意图显示
    public List<Card> card=new List<Card>();//具体的执行功能函数
    private Queue<BattleCommand> battles=new Queue<BattleCommand>();
    public override void Attack()
    {
        if(battles.Count==0)
        {
            Addintent();
        }
        else
        {
            //加入攻击列表
            while(battles.Count > 0)
            {
                CombatManager.combatManager.SetbattleCommand(battles.Dequeue());
            }
        }
        Debug.Log("攻击玩家");
    }
    //显示意图
    public void Addintent()
    {
        BattleCommand battle=new BattleCommand();
        battle.Caster=Caster;
        battle.Target=Target;
        battle.card=card[Random.Range(0,card.Count)];
        battles.Enqueue(battle);
        MonsterEvent Event=Caster.GetComponent<MonsterEvent>();
        Event.TriggerSignal<Card>("意图",battle.card);
    }
}
