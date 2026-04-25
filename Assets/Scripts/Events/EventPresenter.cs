using UnityEngine;
using System.Collections.Generic;

public class EventPresenter : MonoBehaviour
{
    [Header("Connections")]
    public EventUI eventUI;

    private Queue<GameEvent> eventQueue = new Queue<GameEvent>();
    private bool isShowingEvent = false;

    private float maxTime = 10f;
    private float timeRemaining;

    private GameEvent currentActiveEvent;

    void Update()
    {

        if (isShowingEvent)
        {
            timeRemaining -= Time.deltaTime;

            eventUI.UpdateTimerBar(timeRemaining / maxTime);

            if (timeRemaining <= 0)
            {

                int randomChoice = Random.Range(0, currentActiveEvent.buttonChoices.Length);

                Debug.Log("time end randomly selected option: " +  randomChoice);

                OnOptionSelected(randomChoice);

                ForceCloseEvent();
            }
        }
    }

    public void TriggerNewEvent(int eventIndex)
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

            currentActiveEvent = eventToShow;

            timeRemaining = maxTime;

            eventUI.ShowEvent(eventToShow);
        }
        else
        {
            isShowingEvent = false;
            eventUI.HidePanel();
        }
    }

    private void ForceCloseEvent()
    {
        eventUI.HidePanel();
        isShowingEvent = false;
        ShowNextEvent();
    }

    public void OnOptionSelected(int choiceIndex)
    {
        Debug.Log("Player clicked option: " + choiceIndex);

        Debug.Log(currentActiveEvent.choicesEffects.Length);
        Debug.Log(currentActiveEvent.eventDescription);

        Effect[] effectsToApply = currentActiveEvent.choicesEffects[choiceIndex].effects;

        if (effectsToApply != null)
        {
            foreach (Effect currentEffect in effectsToApply)
            {
                if (currentEffect != null)
                {
                    CountryManager.ApplyEffect(currentEffect.CountryId, currentEffect);
                    Debug.Log("Applied effect to: " +  currentEffect.CountryId);
                }
            }
        }

        ForceCloseEvent();
    }


}