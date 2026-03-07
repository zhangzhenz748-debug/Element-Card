using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trrig : MonoBehaviour//信号
{
    public MonsterEvent monster;
    public void Bar()
    {
        monster.TriggerSignal<(int,int)>("血条",(50,100));
        Debug.Log("创建");
    }
}
