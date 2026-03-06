using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
[Serializable]
public class MonsterSignal
{
    public string signalName; // 指令名
    public UnityEvent<MonsterBase> response; // 面板里拖入的各种函数
}
public class MonsterEvent : MonoBehaviour//局部观察者
{
    public List<MonsterSignal> monsters;//指令面板
    private Dictionary<string, UnityEvent<MonsterBase>> _event = new Dictionary<string, UnityEvent<MonsterBase>>();
    void Awake()
    {
        foreach (var i in monsters)
        {
            if (string.IsNullOrEmpty(i.signalName)) continue;

            // 如果字典里还没有这个信号，就加进去
            if (!_event.ContainsKey(i.signalName))
            {
                _event.Add(i.signalName, i.response);
            }
            else
            {
                Debug.LogWarning($"物体 {gameObject.name} 上有重复的信号名: {i.signalName}");
            }
        }
    }
    public void TriggerSignal<T>(string name, T value)//调用有参方法
    {
        MonsterGame<T> packet = new MonsterGame<T>(value);
        if (_event.TryGetValue(name, out UnityEvent<MonsterBase> response))
        {
            response?.Invoke(packet);
        }
    }
    public void TriggerSignal(string name)//调用无参方法
    {
        if (_event.TryGetValue(name, out UnityEvent<MonsterBase> response))
        {
            response?.Invoke(null);
        }
    }
}
