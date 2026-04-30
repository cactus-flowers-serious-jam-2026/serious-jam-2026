using UnityEngine;
using UnityEngine.UI;

public class ResourceBubble : MonoBehaviour
{
    private Button resourceBubbleButton;
    public string type;
    public int count;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        resourceBubbleButton = GetComponent<Button>();
    }
    void Start()
    {
        resourceBubbleButton.onClick.AddListener(() =>
        {
            ResourceEvents.OnResourceGathered.Invoke(type, count);
            gameObject.SetActive(false);
        });
    }

    public void DisplayBubble(string type, int count)
    {
        this.type = type;
        this.count = count;
        GetComponent<Button>().image.sprite = Resources.Load<CountryResource>(ResourcesDatabase.TAG_POPUP_SPRITEPATH_MAP[type]).Icon;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
