using System.Collections.Generic;
using UnityEngine;

public class CountryManager : MonoBehaviour
{
    public Dictionary<string, Country> Countries { get; private set; }
    
    public static CountryManager instance;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyEffect(string countryId, Effect e)
    {
        if(Countries.ContainsKey(countryId))
            Countries[countryId].ApplyEffect(e);
    }
}
