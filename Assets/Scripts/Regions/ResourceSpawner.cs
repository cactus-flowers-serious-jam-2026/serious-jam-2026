using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;
using Random = UnityEngine.Random;

public class ResourceSpawner : MonoBehaviour
{
    private Region _region;
    private Dictionary<string, float> _spawnChances;
    private Queue<string> _bubblesQueue;
    
    [SerializeField]
    private ResourceBubble _resourceBubblePrefab;

    private static Canvas _popupsCanvas;

    private void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTickEvent()
    {
        foreach (var resource in _spawnChances)
        {
            float roll = Random.value;
            if (roll <= resource.Value)
                _bubblesQueue.Enqueue(resource.Key);
        }

        if (_bubblesQueue.Count != 0)
        {
            SpawnResourceBubble(_bubblesQueue.Dequeue());
        }
    }

    private void SpawnResourceBubble(string type)
    {
        ResourceBubble bubble = Instantiate(_resourceBubblePrefab, _region.transform);
        bubble.type = type;
        bubble.count = Random.Range(5, 15);
        bubble.icon = Resources.Load<Sprite>("Sprites/" + type);
        bubble.GetComponentInChildren<Image>().sprite = bubble.icon;
    }
}
