using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum ManagerKeys
{
    LifeEvent,
    keyEvent,   
}

public static class EventManager
{
    public static Dictionary<ManagerKeys, EventMethod> EventContainer = new Dictionary<ManagerKeys, EventMethod>();

    public delegate void EventMethod(params object[] parameters);

    public static void Suscribe(ManagerKeys eventType, EventMethod method)
    {
        if (EventContainer.ContainsKey(eventType))
            EventContainer[eventType] += method;
        else
            EventContainer.Add(eventType, method);
    }

    public static void UnSuscribe(ManagerKeys eventType, EventMethod method)
    {
        if (EventContainer.ContainsKey(eventType))
        {
            EventContainer[eventType] -= method;

            if (EventContainer[eventType] == null)
            {
                EventContainer.Remove(eventType);
            }
        }
    }

    public static void Trigger(ManagerKeys eventType, params object[] parameters)
    {
        if (EventContainer.ContainsKey(eventType))
            EventContainer[eventType](parameters);
    }
}