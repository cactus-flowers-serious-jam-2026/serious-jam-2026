using UnityEngine;


[CreateAssetMenu(fileName = "New Event", menuName = "Strategy Game/Event")]
public class GameEvent : ScriptableObject
{

    public string eventTitle;
    [TextArea(3, 5)]
    public string eventDescription;
}
