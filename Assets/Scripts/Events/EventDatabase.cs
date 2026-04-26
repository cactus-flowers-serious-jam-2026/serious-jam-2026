using System.Collections.Generic;
using UnityEngine;

public class EventDatabase : MonoBehaviour
{
    [Header("Drag all your Event files here!")]

    public static List<GameEvent> GlobalEvents = new List<GameEvent>();

    void Awake()
    {
        var events = Resources.LoadAll<GameEvent>("Events");
        
        foreach (var e in events)
            GlobalEvents.Add(e);
    }
}
