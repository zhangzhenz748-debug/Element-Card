using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    
}
public enum TargetingMode//卡牌属性模式：决定是放到敌人上触发还是不用放到敌人上触发
{
    None,           // 不需要目标（比如：抽两张牌、全局加血）
    SingleEnemy,    // 需要指向一个敌人（比如：单体伤害、施加虚弱）
}
