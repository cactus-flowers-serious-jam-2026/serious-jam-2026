using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Country : MonoBehaviour
{
    public Region[] _regions { get; private set;  }
    
    [SerializeField]
    private int[] regionIDs;
    
    private Dictionary<Parameter, float> _parameters;

    public Dictionary<string, CountryResource> CountryResources { get; private set; } =
        new Dictionary<string, CountryResource>();
    
    
    void Awake()
    {
        CountryResources = new Dictionary<string, CountryResource>
        {
            { GLOBAL_TAGS.ECOLOGY_RES_TAG,  Resources.Load<CountryResource>("CountryResources/Ecological") },
            { GLOBAL_TAGS.MILITARY_RES_TAG, Resources.Load<CountryResource>("CountryResources/Military") },
            { GLOBAL_TAGS.POLITICAL_RES_TAG, Resources.Load<CountryResource>("CountryResources/Political") }
        };

        foreach (var res in CountryResources)
        {
            res.Value.SetCount(0);
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _regions = FindObjectsByType<Region>(FindObjectsSortMode.None)
                    .Where(r => regionIDs.Contains(r.ID))
                    .Select(r => r)
                    .ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectResource(string type, int count)
    {
        if (CountryResources.ContainsKey(type))
            CountryResources[type].IncreaseCount(count);
    }

    public void ApplyEffect(Effect e)
    {
        for (int i = 0; i < e.ParameterChanges[0].Changes.Length; i++)
        {
            ParameterChange p = e.ParameterChanges[0].Changes[i];
            if (_parameters.ContainsKey(p.parameter))
                _parameters[p.parameter] = Math.Clamp(_parameters[p.parameter] + p.change, 0.0f, 1.0f);
            
            Debug.Log(p.parameter + " " + p.change);
        }

        for (int i = 1; i < e.ParameterChanges.Length; i++)
            for (int j = 0; j < e.ParameterChanges[i].Changes.Length; j++) 
                _regions[i].ApplyChange(e.ParameterChanges[i].Changes[j]);
    }
}
