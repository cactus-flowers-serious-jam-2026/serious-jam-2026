using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountryResView : MonoBehaviour
{
    public GameObject resourceDisplayPrefab;
    private Dictionary<string, CountryResource> _countryResources;
    private Dictionary<string, TextMeshProUGUI> _resourceDisplays = new Dictionary<string, TextMeshProUGUI>();

    void Awake()
    {
        _countryResources = new Dictionary<string, CountryResource>
        {
            {"eco", Resources.Load<CountryResource>("CountryResources/Ecological")},
            {"mil", Resources.Load<CountryResource>("CountryResources/Military")},
            {"pol", Resources.Load<CountryResource>("CountryResources/Political")}
        };

        int i = 0;
        foreach (var resource in _countryResources)
        {
            GameObject resourceDisplay = Instantiate(resourceDisplayPrefab, transform);
            resourceDisplay.GetComponentInChildren<TextMeshProUGUI>().text = resource.Value.GetCount().ToString();
            resourceDisplay.GetComponentInChildren<Image>().overrideSprite = resource.Value.Icon;
            resourceDisplay.GetComponent<RectTransform>().anchoredPosition =  new Vector2(30 + i * 70f, 0);
            _resourceDisplays.Add(resource.Key, resourceDisplay.GetComponentInChildren<TextMeshProUGUI>());
            i++;
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Display(Dictionary<string, CountryResource> resources)
    {
        foreach (var resource in resources)
            if(_resourceDisplays.ContainsKey(resource.Key))
                _resourceDisplays[resource.Key].text = resource.Value.GetCount().ToString();            
    }
}
