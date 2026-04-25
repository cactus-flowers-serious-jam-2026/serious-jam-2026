using UnityEngine;
using UnityEngine.Events;

public class GameTickManager : MonoBehaviour
{

    [Header("The Megaphone")]

    public UnityEvent<int> fireEvent;

    private SimpleTimer myTimer;


    void Start()
    {

        float firstRandomTime = Random.Range(15f , 30f);

        myTimer = new SimpleTimer(firstRandomTime);
    }

   
    void Update()
    {
       bool isTimerFinished = myTimer.Tick(Time.deltaTime);

        if (isTimerFinished)
        {

            int totalEvents = EventDatabase.GlobalEvents.Length;

            int randomEventNumber = Random.Range(0, totalEvents);

            fireEvent.Invoke(randomEventNumber);

            float randomTime = Random.Range(15f, 30f);

            myTimer = new SimpleTimer(randomTime);

        }

    }

}
