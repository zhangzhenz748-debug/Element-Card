using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventCenter
{
    private static EventCenter instance;
    public static EventCenter Instance
    {
        get{
		if(instance==null)
		{
		instance=new EventCenter();
		}
		return instance;
		}
    }
    private Dictionary<string,IEventInfo> _event=new Dictionary<string, IEventInfo>();
    //添加方法
    public void AddEvent(string name,UnityAction action)
    {
        if(_event.ContainsKey(name))
        {
            //如果已经包含
            (_event[name] as EventInfo).actions+=action;
        }
        else
        {
            _event.Add(name,new EventInfo(action));
        }
    }public void AddEvent<T>(string name,UnityAction<T> action)
    {
        if(_event.ContainsKey(name))
        {
            //如果已经包含
            (_event[name] as EventInfo<T>).actions+=action;
        }
        else
        {
            _event.Add(name,new EventInfo<T>(action));
        }
    }
    //执行方法
    public void EventTrigger(string name)
    {
        if(_event.ContainsKey(name))
		{
			if((_event[name] as EventInfo).actions != null)
			{
				(_event[name] as EventInfo).actions.Invoke();
			}
		}
    }
    public void EventTrigger<T>(string name,T info)
    {
        if(_event.ContainsKey(name))
		{
			if((_event[name] as EventInfo<T>).actions != null)
			{
				(_event[name] as EventInfo<T>).actions.Invoke(info);
			}
		}
    }
    //去除
    public void Remove(string name,UnityAction action)
	{
		if(_event.ContainsKey(name))
		{
			(_event[name] as EventInfo).actions-=action;
		}
	}
    public void Remove<T>(string name,UnityAction<T> action)
	{
		if(_event.ContainsKey(name))
		{
			(_event[name] as EventInfo<T>).actions-=action;
		}
	}
    public void Clear()
    {
        _event.Clear();
    }
}