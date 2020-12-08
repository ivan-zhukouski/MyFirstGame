using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class ParametrizedEvent : UnityEvent<Hashtable> { };
public class EventManager : MonoBehaviour
{

    private Dictionary<GameEvent, ParametrizedEvent> eventDictionary;

    private static EventManager eventManager;

    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<GameEvent, ParametrizedEvent>();
        }
    }

    public static void StartListening(GameEvent eventName, UnityAction<Hashtable> listener)
    {
        ParametrizedEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new ParametrizedEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(GameEvent eventName, UnityAction<Hashtable> listener)
    {
        if (eventManager == null) return;
        ParametrizedEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(GameEvent eventName, Hashtable eventArgs = default(Hashtable))
    {
        ParametrizedEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(eventArgs);
        }
    }
}