using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class EventUI : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject eventPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descText;

    private Queue<GameEvent> eventQueue = new Queue<GameEvent>();

    private bool isShowingEvent = false;

    void Start()
    {
        eventPanel.SetActive(false);
    }

    
    public void DisplayEventOnScreen(int eventIndex)
    {
        
        GameEvent chosenEvent = EventDatabase.GlobalEvents[eventIndex];

        eventQueue.Enqueue(chosenEvent);

        // 3. If we are NOT currently showing an event, tell the line to move forward!
        if (isShowingEvent == false)
        {
            ShowNextEvent();
        }
    }

    private void ShowNextEvent()
    {
        if (eventQueue.Count > 0)
        {
            isShowingEvent = true;

            GameEvent eventToShow = eventQueue.Dequeue();

            titleText.text = eventToShow.eventTitle;
            descText.text = eventToShow.eventDescription;

            eventPanel.SetActive(true);

            Invoke("HidePanel", 3f);
        }
        else
        {
            isShowingEvent = false;
            eventPanel.SetActive(false);
        }
    }

    private void HidePanel()
    {
        eventPanel.SetActive(false);

        ShowNextEvent();
    }
}