using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameTickManager : MonoBehaviour
{

    [Header("The Megaphone")]

    public UnityEvent<int> fireEvent;

    public static UnityEvent tickEvent = new UnityEvent();

    private SimpleTimer myTimer;

    private List<GameEvent> totalEvents;

    private int randomEventNumber;

    [SerializeField] private float chanceToSpawnEvent;

    [SerializeField] private float randomTimeMin;
    [SerializeField] private float randomTimeMax;
    
    private void Awake()
    {
        totalEvents = EventDatabase.GlobalEvents;
    }
    


    void Start()
    {

        float firstRandomTime = 2.5f;//Random.Range(15f , 30f);

        myTimer = new SimpleTimer(firstRandomTime);
    }

   
    void Update()
    {
       bool isTimerFinished = myTimer.Tick(Time.deltaTime);

        if (isTimerFinished)
        {
            tickEvent.Invoke();
            
            
            if (totalEvents.Count > 0 && Random.value < chanceToSpawnEvent)
            {
                randomEventNumber = Random.Range(0, totalEvents.Count);
                fireEvent.Invoke(randomEventNumber);
                AudioEvents.InvokeOnEventPoppedUp();
                totalEvents.RemoveAt(randomEventNumber);
            }
            
            if (totalEvents.Count == 0)Debug.Log("No more events...");


            //float randomTime = Random.Range(randomTimeMin, randomTimeMax);

            //myTimer = new SimpleTimer(randomTime);

        }

    }

}
