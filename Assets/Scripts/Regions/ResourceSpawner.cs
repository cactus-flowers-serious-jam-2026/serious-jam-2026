using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;
using Random = UnityEngine.Random;

public class ResourceSpawner : MonoBehaviour
{
    private Region[] _regions;
    //private Dictionary<string, float> _spawnChances;
    private Queue<string> _bubblesQueue;
    
    private readonly string[] _resources = {GLOBAL_TAGS.ECOLOGY_RES_TAG, GLOBAL_TAGS.MILITARY_RES_TAG, GLOBAL_TAGS.POLITICAL_RES_TAG};

    public static Canvas ResourceCanvas;

    //private static Canvas _popupsCanvas;

    private void Awake()
    {
        ResourceCanvas = FindObjectsByType<Canvas>(FindObjectsSortMode.None).First(c => c.CompareTag("Resource Canvas"));
        //Debug.Log("Found Resource Canvas: " + ResourceCanvas.tag);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        _regions = FindObjectsByType<Region>(FindObjectsSortMode.None)
            .Where(r => CountryManager.CountryRegions["Poland"].Contains(r.ID)).ToArray();
        GameTickManager.tickEvent.AddListener(OnTickEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTickEvent()
    {
        //Debug.Log("Tick");
        foreach (var region in  _regions)
        {
            foreach (var resource in _resources)
            {
                float spawnChance = 0.0f;
                
                switch (resource)
                {
                    case GLOBAL_TAGS.ECOLOGY_RES_TAG:
                        foreach (var param in region.Parameters)
                        {
                            switch (param.Key.Name)
                            {
                                case "Happiness":
                                    //Debug.Log("Penis check parameter");
                                    spawnChance += 0.005f * (1f - param.Value);
                                    break;
                                
                                case "Interest in politics":
                                    spawnChance += 0.005f * param.Value;
                                    break;
                                
                                case "Pollution":
                                    spawnChance += 0.010f * param.Value;
                                    break;
                            }
                        }                        
                        break;

                    case GLOBAL_TAGS.MILITARY_RES_TAG:
                        foreach (var param in region.Parameters)
                        {
                            switch (param.Key.Name)
                            {
                                case "Interest in politics":
                                    spawnChance += 0.0025f * param.Value;
                                    break;
                                
                                case "War support":
                                    spawnChance += 0.01f * param.Value;
                                    break;
                                
                                case "Stability":
                                    spawnChance += 0.005f * param.Value;
                                    break;
                            }
                        }   
                        break;
                    
                    case GLOBAL_TAGS.POLITICAL_RES_TAG:
                        //Debug.Log(GLOBAL_TAGS.POLITICAL_RES_TAG);
                        foreach (var param in region.Parameters)
                        {
                            switch (param.Key.Name)
                            {
                                case "Interest in politics":
                                    spawnChance += 0.015f * param.Value;
                                    break;
                                
                                case "Stability":
                                    spawnChance += 0.01f * (1f - param.Value);
                                    break;
                                
                                case "Pollution":
                                    spawnChance += 0.0001f * param.Value;
                                    break;
                            }
                        }   
                        break;
                }

                spawnChance /= 3;
                float roll = Random.value;

                if (roll <= spawnChance)
                {
                    region.SpawnResource(resource, Random.Range(5, 8));
                    break;
                }
                //_bubblesQueue.Enqueue(resource);
            }
        }
        

        /*
        if (_bubblesQueue.Count != 0)
        {
            SpawnResourceBubble(_bubblesQueue.Dequeue());
        }
        */
    }
}
