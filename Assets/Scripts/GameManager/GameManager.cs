using System;
using UnityEngine;

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
        WorldTension += TensionPerTick;

        if (WorldTension > TensionMaximumThreshold)
        {
            Debug.Log("YOU LOST");
        }

        if (WorldTension < TensionMinimumThreshold)
        {
            Debug.Log("YOU WON");
        }
    }
    
}
