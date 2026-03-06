using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 数据包
/// </summary>
public class BattleCommand
{
    public MonsterTrait Caster;//发起者
    public MonsterTrait Target;//接受者
    public Card card;//具体的执行功能函数
}
public class CombatManager : MonoBehaviour
{
    public static CombatManager combatManager;
    private Queue<BattleCommand> ts;
    private bool _isBusy = false;
    private AbstractGameAction action;
    void Awake()
    {
        if (combatManager != null && combatManager != this)
        {
            Destroy(gameObject);
        }
        combatManager = this;
        ts = new Queue<BattleCommand>();
        action=new AbstractGameAction();
    }
    public void SetbattleCommand(MonsterTrait caster, MonsterTrait monster, Card card)
    {
        BattleCommand newCmd = new BattleCommand();
        newCmd.Caster = caster;
        newCmd.Target = monster;
        newCmd.card = card;
        StartCombat(newCmd);
    }
    ///<summary>
    /// 执行战斗管理器
    ///</summary>
    public void StartCombat(BattleCommand battle)
    {
        ts.Enqueue(battle);
        if (!_isBusy)
        {
            StartCoroutine(ExecuteRoutine());
        }
    }
    ///<summary>
    /// 开始计算
    /// </summary>
    private IEnumerator ExecuteRoutine()
    {
        _isBusy = true;

        while (ts.Count > 0)
        {
            BattleCommand cmd = ts.Dequeue();
            // --- A. 计算层 (Logic) ---
            // 此时进行数值计算，比如：基础伤害 + 玩家力量 - 敌人护盾

            //进行能量检查
            if (eneray._eneray.SetText(cmd.card.baseData.Eneray))
            {
                if (cmd.card.cost)
                {
                    action.Caster=cmd.Caster;
                    action.Target=cmd.Target;
                    action.harm=cmd.card.baseData.power;
                    cmd.card.cost.Excute(action);
                }
                cmd.card.Excute();
            }
            // --- B. 表现层 (Presentation) ---
            // 1. 触发攻击动画或卡牌飞向目标的表现
            yield return new WaitForSeconds(0.3f); // 等待动作前摇
            // 2. 真正应用数值变化 (扣血/加盾)
            // 3. 停顿，让玩家看清血条减少或数值弹出
            yield return new WaitForSeconds(0.5f);
        }
        _isBusy = false;
    }
}
