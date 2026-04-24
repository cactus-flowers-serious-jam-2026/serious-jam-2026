using UnityEngine;

public class SimpleTimer 
{
    private float timeRemaining;
    private float startingTime;

    public SimpleTimer(float timeToSet)
    {
        startingTime = timeToSet;
        timeRemaining = timeToSet;
    }

    public bool Tick(float deltaTime)
    {
        timeRemaining -= deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = startingTime;
            return true;

        }

        return false;
    }
}
