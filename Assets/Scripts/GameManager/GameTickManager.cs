using UnityEngine;
using UnityEngine.Events;

public class GameTickManager : MonoBehaviour
{

    [Header("The Megaphone")]

    public UnityEvent<int> fireEvent;

    public static UnityEvent tickEvent = new UnityEvent();

    private SimpleTimer myTimer;


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
            int totalEvents = EventDatabase.GlobalEvents.Length;

            int randomEventNumber = Random.Range(0, totalEvents);

            fireEvent.Invoke(randomEventNumber);

            float randomTime = Random.Range(2.5f, 2.5f);

            myTimer = new SimpleTimer(randomTime);

        }

    }

}
