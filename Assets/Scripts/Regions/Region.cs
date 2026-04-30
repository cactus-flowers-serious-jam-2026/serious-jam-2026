using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Region : MonoBehaviour
{
    private static int Counter = 1;
    public int ID;

    public Dictionary<Parameter, float> Parameters { get; private set; } = new Dictionary<Parameter, float>();
    public Action[] Actions { get; private set; }

    [SerializeField]
    private ResourceBubble ResourceBubblePrefab;
    private ResourceBubble ResourceBubble;
    
    

    void Awake()
    {
        ID = Counter++;
        LoadAllParameters();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResourceBubble = Instantiate(ResourceBubblePrefab, ResourceSpawner.ResourceCanvas.transform);
        ResourceBubble.transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y + 0.5f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadAllParameters()
    {
        Parameter[] paramsArray = ResourcesDatabase.parameters;

        foreach (Parameter param in paramsArray)
        {
            Parameters.Add(param, Random.Range(0.8f, 1f));
        }
        
    }

    public void ApplyChange(ParameterChange pc)
    {
        Parameters[pc.parameter] = Math.Clamp(Parameters[pc.parameter] + pc.change, 0.0f, 1.0f); 
        Debug.Log(pc.parameter + " " + pc.change);
    }

    public void SpawnResource(string type, int count)
    {
        if(!ResourceBubble.gameObject.activeInHierarchy)
            ResourceBubble.DisplayBubble(type, count);
    }
}
