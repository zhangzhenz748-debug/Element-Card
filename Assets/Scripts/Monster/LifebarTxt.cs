using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifebarTxt : MonoBehaviour//敌人血条数字修改
{
    public Text text;
    public void SetText(MonsterBase monster)
    {
        if (monster is MonsterGame<(int blood, int max)> packet)
        {
            var (current, total) = packet.Value;
            text.text=current.ToString();
        }
        else
        {
            // 如果传错了包（比如传了个字符串包），这里可以报错提醒
            Debug.LogWarning($"{gameObject.name} 收到错误类型的信号数据！");
        }
    }
}
