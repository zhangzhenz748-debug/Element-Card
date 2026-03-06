using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trrig : MonoBehaviour//信号
{
    public MonsterEvent monster;
    public void Bar()
    {
        monster.TriggerSignal<(int,int)>("血条",(50,100));
        MonsterGame<int> monst=new MonsterGame<int>(3);
        EventCenter.Instance.EventTrigger<MonsterBase>("创建敌人",monst);
        Debug.Log("创建");
    }
}
