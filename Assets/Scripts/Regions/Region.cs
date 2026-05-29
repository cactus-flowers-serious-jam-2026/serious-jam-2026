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
    
    private static float paramDecreasePerTick = 0.003f;

    private static Effect blankEffect;

    [SerializeField]
    private ResourceBubble ResourceBubblePrefab;
    private ResourceBubble ResourceBubble;

    public bool selected = false;

    void Awake()
    {
        ID = Counter++;
        LoadAllParameters();
        blankEffect = Resources.Load<Effect>("Effects/generic/blank");
    }
    
    
    void Start()
    {
        ResourceBubble = Instantiate(ResourceBubblePrefab, ResourceSpawner.ResourceCanvas.transform);
        ResourceBubble.transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y + 0.5f, transform.position.z);
        
        GameTickManager.tickEvent.AddListener(OnTick);
    }
    
    private void OnTick()
    {
        foreach (Parameter param in new List<Parameter>(Parameters.Keys))
        {
            Parameters[param] = Mathf.Clamp(Parameters[param] - paramDecreasePerTick, 0.0f, 1.0f);
        }
        CountryManager.ApplyEffect("Poland", blankEffect);
        
        if(selected)
            SelectionUIEvents.OnRegionParamsUpdated.Invoke(this);
    }
    

    private void LoadAllParameters()
    {
        Parameter[] paramsArray = ResourcesDatabase.parameters;

        foreach (Parameter param in paramsArray)
        {
            if(param.Name != "World Tension")
                Parameters.Add(param, Random.Range(0.5f, 0.8f));
        }
        
    }

    public void ApplyChange(ParameterChange pc)
    {
        Debug.Log(Parameters[pc.parameter]);
        Parameters[pc.parameter] = Math.Clamp(Parameters[pc.parameter] + pc.change, 0.0f, 1.0f); 
        Debug.Log(pc.parameter + " " + pc.change);
        Debug.Log(Parameters[pc.parameter]);
    }

    public void SpawnResource(string type, int count)
    {
        if(!ResourceBubble.gameObject.activeInHierarchy)
            ResourceBubble.DisplayBubble(type, count);
    }
}
