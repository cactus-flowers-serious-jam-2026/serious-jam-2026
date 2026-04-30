using System;
using System.Collections.Generic;
using System.Linq;
using Events;
using UnityEngine;

public class Country : MonoBehaviour
{
    public Region[] _regions { get; private set; }
    
    //[SerializeField]
    private int[] regionIDs = new int[480];
    
    public Dictionary<Parameter, float> parameters = new Dictionary<Parameter, float>();

    public Dictionary<string, CountryResource> CountryResources { get; private set; } =
        new Dictionary<string, CountryResource>();
    
    
    void Awake()
    {
        for(int i = 1; i <  regionIDs.Length; i++)
            regionIDs[i - 1] = i;
        
        _regions = FindObjectsByType<Region>(FindObjectsSortMode.None)
            .Where(r => regionIDs.Contains(r.ID))
            .ToArray();
        
        CountryResources = new Dictionary<string, CountryResource>
        {
            { GLOBAL_TAGS.ECOLOGY_RES_TAG,  Resources.Load<CountryResource>("CountryResources/Ecological") },
            { GLOBAL_TAGS.MILITARY_RES_TAG, Resources.Load<CountryResource>("CountryResources/Military") },
            { GLOBAL_TAGS.POLITICAL_RES_TAG, Resources.Load<CountryResource>("CountryResources/Political") }
        };

        foreach (var res in CountryResources)
            res.Value.SetCount(0);
        
        parameters = new Dictionary<Parameter, float>()
        {
            {Resources.Load<Parameter>("Parameters/Pollution"), 0.60f},
            {Resources.Load<Parameter>("Parameters/Happines"), 0.60f},
            {Resources.Load<Parameter>("Parameters/Interest_in_politics"), 0.67f},
            {Resources.Load<Parameter>("Parameters/Stability"), 0.87f},
            {Resources.Load<Parameter>("Parameters/War_support"), 0.15f}
        };
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _regions = FindObjectsByType<Region>(FindObjectsSortMode.None)
                    .Where(r => regionIDs.Contains(r.ID))
                    .Select(r => r)
                    .ToArray();
        
        
        parameters = new Dictionary<Parameter, float>()
        {
            {Resources.Load<Parameter>("Parameters/Pollution"), 0.60f},
            {Resources.Load<Parameter>("Parameters/Happines"), 0.60f},
            {Resources.Load<Parameter>("Parameters/Interest_in_politics"), 0.67f},
            {Resources.Load<Parameter>("Parameters/Stability"), 0.87f},
            {Resources.Load<Parameter>("Parameters/War_support"), 0.15f}
        };
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
            if (parameters.ContainsKey(p.parameter))
                parameters[p.parameter] = Math.Clamp(parameters[p.parameter] + p.change, 0.0f, 1.0f);
            
            Debug.Log(p.parameter + " " + p.change);
        }

        for (int i = 1; i < e.ParameterChanges.Length; i++)
            for (int j = 0; j < e.ParameterChanges[i].Changes.Length; j++) 
                _regions[i].ApplyChange(e.ParameterChanges[i].Changes[j]);
    }

    private void RecalculateRegionalParameters()
    {
        
    }
}
