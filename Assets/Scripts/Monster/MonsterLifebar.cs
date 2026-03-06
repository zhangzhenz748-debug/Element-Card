using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterLifebar : MonoBehaviour, MonsterBase//血条slider
{
    public Slider slider;
    public void Lifebar(MonsterBase monster)
    {
        if (monster is MonsterGame<(int blood, int max)> packet)
        {
            var (current, total) = packet.Value;
            if (total != 0)
            {
                slider.value = (float)current / total;
            }
        }
        else
        {
            // 如果传错了包（比如传了个字符串包），这里可以报错提醒
            Debug.LogWarning($"{gameObject.name} 收到错误类型的信号数据！");
        }
    }
}
