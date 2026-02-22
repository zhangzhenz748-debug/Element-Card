using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

// 事件信息接口，用于字典统一存储
public interface IEventInfo { }
// 内部类：无参数事件包裹
public class EventInfo : IEventInfo
{
    public UnityAction actions;
    public EventInfo(UnityAction action) => actions += action;
}
// 内部类：带参数事件包裹
public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> actions;
    public EventInfo(UnityAction<T> action) => actions += action;
}
