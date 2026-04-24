using System;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    public Dictionary<Parameter, float> Parameters { get; private set; }
    public Action[] Actions { get; private set; }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyChange(Effect e)
    {
        foreach (var pc in e.ParameterChanges)
            Parameters[pc.parameter] = Math.Clamp(Parameters[pc.parameter] + pc.change, 0.0f, 1.0f);
    }
}
