using System;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    private static int Counter = 1;
    public int ID;
    
    public Dictionary<Parameter, float> Parameters { get; private set; }
    public Action[] Actions { get; private set; }

    void Awake()
    {
        ID = Counter++;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyChange(ParameterChange pc)
    {
        Parameters[pc.parameter] = Math.Clamp(Parameters[pc.parameter] + pc.change, 0.0f, 1.0f); 
        Debug.Log(pc.parameter + " " + pc.change);
    }
}
