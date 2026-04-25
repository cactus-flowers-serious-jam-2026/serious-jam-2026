using UnityEngine;

public enum EventScope
{
    Local,
    Global
}

[CreateAssetMenu(fileName = "New Event", menuName = "Strategy Game/Event")]
public class GameEvent : ScriptableObject
{
    [Header("Event Info")]
    public string eventTitle;
    [TextArea(3, 5)]
    public string eventDescription;

    public EventScope scope;

    [Header("Player Choice")]
    public string[] buttonChoices;

}
