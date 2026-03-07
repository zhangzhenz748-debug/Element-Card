using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MonsterDrop : MonoBehaviour, IDropHandler
{
    public TargetingMode Mode;//触发的模式
    private MonsterTrait play;
    void Start()
    {
        play = Player.player.GetComponent<MonsterTrait>();
        if (play == null)
        {
            Debug.Log("没有找到玩家");
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        GameObject game = eventData.pointerDrag;
        Card card = game.GetComponent<Card>();
        if (card == null)
        {
            Debug.Log("card为空");
            return;
        }
        if (card.baseData.targeting == Mode)
        {
            MonsterTrait Monster = gameObject.GetComponent<MonsterTrait>();
            CombatManager.combatManager.SetbattleCommand(play, Monster, card);
        }
        // MonsterEvent monster=GetComponent<MonsterEvent>();
        // monster.TriggerSignal<int>(signalName,-card.baseData.power);

        //发送一个被攻击的信号
        Debug.Log("我被攻击了");
    }
}
