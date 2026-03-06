using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MonsterBase//数据包装基类
{
    
}
public class MonsterGame:MonsterBase
{
}
public class MonsterGame<T>:MonsterBase
{
    public T Value;

    // 建议：由于 ScriptableObject 实例化泛型很麻烦，
    // 如果只是为了传参，建议这里直接用普通的 class，性能更好且更灵活。
    public MonsterGame(T value)
    {
        this.Value = value;
    }
}