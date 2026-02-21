using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AbstractGameAction//数据
{
    public Monster Source;      // 谁发的
    public List<Monster> Targets; // 打谁
    public int harm;   //伤害  
    public Sprite image;//图片
    //public int defense;//防御
    public string name;//卡牌名称
    public string s;//卡牌描述
    public AbstractGameAction()
    {
        // 关键：必须 new 出来，内存里才有这个列表
        Targets = new List<Monster>(); 
    }
    public void Clase()
    {
        Targets.Clear();
    }
}
