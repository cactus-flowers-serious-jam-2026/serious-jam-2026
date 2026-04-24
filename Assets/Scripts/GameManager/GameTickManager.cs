using UnityEngine;
using UnityEngine.Events;

public class GameTickManager : MonoBehaviour
{

    [Header("The Megaphone")]

    public UnityEvent<int> fireEvent;

    private SimpleTimer myTimer;

    void Start()
    {
        myTimer = new SimpleTimer(5f);
    }

   
    void Update()
    {
       bool isTimerFinished = myTimer.Tick(Time.deltaTime);

       if (isTimerFinished)  
       {
            int totalEvents = EventDatabase.GlobalEvents.Length;

            int randomEventNumber = Random.Range(0, totalEvents);

            fireEvent.Invoke(randomEventNumber);
       }

    }

}
