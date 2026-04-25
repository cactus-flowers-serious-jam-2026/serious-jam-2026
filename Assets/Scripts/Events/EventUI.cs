using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class EventUI : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject eventPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descText;

    [Header("Choice Buttons")]
    public GameObject[] choiceButtons;
    public TextMeshProUGUI[] buttonTexts;

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

            SetupButtons(eventToShow);

            eventPanel.SetActive(true);



            Invoke("HidePanel", 3f);
        }
        else
        {
            isShowingEvent = false;
            eventPanel.SetActive(false);
        }
    }

    private void SetupButtons(GameEvent currentEvent)
    {
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            choiceButtons[i].SetActive(false);
        }

        for (int i = 0;i < currentEvent.buttonChoices.Length; i++)
        {
            if (i < choiceButtons.Length)
            {
                choiceButtons[i].SetActive(true);
                buttonTexts[i].text = currentEvent.buttonChoices[i];
            }
        }
    }

    private void HidePanel()
    {
        eventPanel.SetActive(false);

        ShowNextEvent();
    }
}