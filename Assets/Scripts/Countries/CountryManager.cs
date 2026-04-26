using System.Collections.Generic;
using UnityEngine;

public class CountryManager : MonoBehaviour
{
    public static Dictionary<string, Country> Countries { get; private set; } = new Dictionary<string, Country>();
    public static CountryManager instance;
    public Country PlayerCountry;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if(instance != this) 
            Destroy(this);
        
        DontDestroyOnLoad(this);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ResourceEvents.OnResourceGathered.AddListener(OnResourceCollected);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ApplyEffect(string countryId, Effect e)
    {
        if(Countries.ContainsKey(countryId))
            Countries[countryId].ApplyEffect(e);
    }

    public static CountryManager GetInstance()
    {
        return instance;
    }

    public Country GetPlayerCountry()
    {
        return PlayerCountry;
    }
    
    public void OnResourceCollected(string type, int count)
    {
        Debug.Log(type + "\t" + count);
        //PlayerCountry.CollectResource(type, count);
    }
}
