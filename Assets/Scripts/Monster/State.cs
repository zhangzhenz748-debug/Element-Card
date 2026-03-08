using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public Dictionary<BuffType, int> _dicBuffType;
    public void AddBuffType(BuffType buff, int date)//加Buff
    {
        if (_dicBuffType.ContainsKey(buff))
        {
            _dicBuffType[buff]+=date;
        }
        else
        {
            _dicBuffType.Add(buff, date);
        }
    }
    public void ReomveBuffType(BuffType buff)
    {
        if (_dicBuffType.ContainsKey(buff))
        {
            _dicBuffType.Remove(buff);
        }
    }
}
public enum BuffType
{
    Strength,    // 力量：每层增加攻击伤害
    Weak,        // 虚弱：造成的攻击伤害减少 25%
    Vulnerable,  // 易伤：受到的伤害增加 50%
    Poison,      // 中毒：回合开始扣血
    Ritual       // 仪式：回合结束获得力量
}
public enum TargetingMode//卡牌属性模式：决定是放到敌人上触发还是不用放到敌人上触发
{
    None,           // 不需要目标（比如：抽两张牌、全局加血）
    SingleEnemy,    // 需要指向一个敌人（比如：单体伤害、施加虚弱）
}
