using TMPro;
using UnityEngine;
using UnityEngine.UI;

enum MoodState
{
    Base,
    Tired,
    Pissed,
    Furious,
    Defeated,
    Smirk
}

public class MoodScript : MonoBehaviour
{
    [SerializeField] private float decreaseMoodInterval = 8;
    private MoodState currentMoodState = MoodState.Base;
    private float lastTension;
    private SimpleTimer decreaseMoodTimer = new SimpleTimer(5);
    
    [SerializeField] private Image MarshalImage;
    [SerializeField] private Sprite[] MarshalSprites;
    
    void Awake()
    {
        //decreaseMoodTimer = new SimpleTimer(decreaseMoodInterval);
    }

    void Start()
    {
        lastTension = GameManager.WorldTension;
        GameTickManager.tickEvent.AddListener(OnTick);
        GameManager.WorldTensionChanged.AddListener(OnTensionChanged);
    }

    void Update()
    {
        
    }

    private void OnTick()
    {
        if (decreaseMoodTimer.Tick(1))
        {
            //Debug.Log("MoodTimer");
            if (currentMoodState != MoodState.Smirk && currentMoodState != MoodState.Base)
                currentMoodState--;
            else if(currentMoodState == MoodState.Base)
                currentMoodState = MoodState.Smirk;
            else
                currentMoodState = MoodState.Base;
        }
        
        MarshalImage.sprite = MarshalSprites[(int)currentMoodState];
    }

    private void OnTensionChanged(float current)
    {
        float delta = current - lastTension;
        lastTension = current;
        
        switch (currentMoodState)
        {
            case MoodState.Base:
                if (delta >= 0.15f)
                    currentMoodState = MoodState.Pissed;
                else if (delta >= 0.05f)
                    currentMoodState = MoodState.Tired;
                else if (delta < 0)
                    currentMoodState = MoodState.Smirk;
                break;
            
            case MoodState.Tired:
                if (delta >= 0.15f)
                    currentMoodState = MoodState.Furious;
                else if (delta >= 0.05f)
                    currentMoodState = MoodState.Pissed;
                else if (delta < 0)
                    currentMoodState--;
                break;
            
            case MoodState.Furious:
                if (delta >= 0.05f)
                    currentMoodState = MoodState.Defeated;
                else if (delta < 0)
                    currentMoodState = MoodState.Pissed;
                break;
            
            case MoodState.Defeated:
                if (delta < 0)
                    currentMoodState = MoodState.Pissed;
                break;
            
            case MoodState.Smirk:
                if(delta >= 0.05f)
                    currentMoodState = MoodState.Tired;
                else if (delta < 0)
                    currentMoodState = MoodState.Base;
                break;
        }
        
        MarshalImage.sprite = MarshalSprites[(int)currentMoodState];
    }
}
