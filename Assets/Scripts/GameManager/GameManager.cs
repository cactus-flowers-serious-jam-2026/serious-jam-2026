using System;
using TMPro;
using UnityEngine;
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

    void Awake()
    {
        if (Instance != null &&  Instance != this)
            Destroy(gameObject);

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        GameTickManager.tickEvent.AddListener(OnTick);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTick()
    {
        CurrentDate = CurrentDate.AddDays(DaysPerTick);
        dateText.text = CurrentDate.ToString("dd.MM.yyyy");
        
        WorldTension += TensionPerTick;
        tensionMeter.fillAmount = WorldTension;
        //tension_text.text = (WorldTension * 100).ToString("F2") + "%";
        
        if (WorldTension > TensionMaximumThreshold)
        {
            Debug.Log("YOU LOST");
        }

        if (WorldTension < TensionMinimumThreshold)
        {
            Debug.Log("YOU WON");
        }
    }

    public static void IncreaseWorldTension(float x)
    {
        WorldTension = Math.Clamp(WorldTension + x, 0.0f, 1.0f);
    }
    
}
