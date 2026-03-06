using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AbstractGameAction//数据
{
    public MonsterTrait Caster;//发起者
    public MonsterTrait Target;//接受者
    public int harm;   //伤害  
    public string name;//卡牌名称
    public string _miao_su;//卡牌描述
    public AbstractGameAction()
    {
    }
    public void Clase()
    {
    }
}
