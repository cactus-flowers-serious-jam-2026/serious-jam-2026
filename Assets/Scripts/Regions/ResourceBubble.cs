using UnityEngine;
using UnityEngine.UI;

public class ResourceBubble : MonoBehaviour
{
    public string type;
    public Sprite icon;
    public int count;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponentInChildren<Button>().onClick.AddListener(() => ResourceEvents.OnResourceGathered.Invoke(type, count));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
