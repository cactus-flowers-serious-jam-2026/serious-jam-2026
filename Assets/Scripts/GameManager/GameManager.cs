using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameManager Instance { get; private set; }
    
    public static float WorldTension = 0.67f;
    public static DateTime CurrentDate = new DateTime(2026, 05, 17);

    [SerializeField] 
    private int DaysPerTick = 7;

    [SerializeField] private float TensionMaximumThreshold = 0.90f;
    [SerializeField] private float TensionMinimumThreshold = 0.10f;
    [SerializeField] private float TensionPerTick = 0.005f;

    //[SerializeField] private TextMeshProUGUI tension_text;
    [SerializeField] private Image tensionMeter;
    
    [SerializeField] private TextMeshProUGUI dateText;
    
    [SerializeField] private SceneTransition fader;
    [SerializeField] private String[] endingSceneNames; 
    /*  0 - lose due to tension
        1 - win due to tension
        2 - win due to time
     */
    
    [SerializeField] private Country PlayerCountry;
    
    public static UnityEvent<float> WorldTensionChanged = new UnityEvent<float>();

    private Parameter stability;
    private Parameter warSupport;
    private Parameter pollution;

    void Awake()
    {
        if (Instance != null &&  Instance != this)
            Destroy(gameObject);

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        GameTickManager.tickEvent.AddListener(OnTick);
        
        stability =  Resources.Load<Parameter>("Parameters/Stability");
        warSupport =  Resources.Load<Parameter>("Parameters/War_support");
        pollution =  Resources.Load<Parameter>("Parameters/Pollution");
    }

    void Start()
    {
        PlayerCountry = CountryManager.instance.PlayerCountry;
    }

    private void OnTick()
    {
        CurrentDate = CurrentDate.AddDays(DaysPerTick);
        dateText.text = CurrentDate.ToString("dd.MM.yyyy");
        
        WorldTension += TensionPerTick;
        tensionMeter.fillAmount = WorldTension;
        //tension_text.text = (WorldTension * 100).ToString("F2") + "%";
        
        WorldTensionChanged.Invoke(WorldTension);
        
        if (WorldTension > TensionMaximumThreshold)
        {
            Debug.Log("YOU LOST");
            fader.LoadNextScene(endingSceneNames[0]);
        }

        if (WorldTension < TensionMinimumThreshold)
        {
            Debug.Log("YOU WON");
            fader.LoadNextScene(endingSceneNames[1]);
        }

        if (CurrentDate.Year >= 2056)
        {
            Debug.Log("YOU WON");
            fader.LoadNextScene(endingSceneNames[2]);
        }

        if (PlayerCountry.parameters_temp[stability] <= 0.1f)
        {
            Debug.Log("YOU LOST");
            fader.LoadNextScene(endingSceneNames[0]);
        }
        
        if (PlayerCountry.parameters_temp[warSupport] >= 0.9f)
        {
            Debug.Log("YOU LOST");
            fader.LoadNextScene(endingSceneNames[0]);
        }
    }

    public static void IncreaseWorldTension(float x)
    {
        WorldTension = Math.Clamp(WorldTension + x, 0.0f, 1.0f);
        WorldTensionChanged.Invoke(WorldTension);
    }
}