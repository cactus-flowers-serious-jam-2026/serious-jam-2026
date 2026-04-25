using UnityEngine;

public class EventDatabase : MonoBehaviour
{
    [Header("Drag all your Event files here!")]
    public GameEvent[] inspectorEvents;

    public static GameEvent[] GlobalEvents;

    void Awake()
    {
        inspectorEvents = Resources.LoadAll<GameEvent>("Events");
        GlobalEvents = inspectorEvents;
    }
}
