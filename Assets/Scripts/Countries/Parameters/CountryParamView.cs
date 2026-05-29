using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountryParamView : MonoBehaviour
{
    public GameObject parameterDisplayPrefab;
    
    private Dictionary<string, Parameter> _countryParameters;
    private Dictionary<string, TextMeshProUGUI> _parameterDisplays = new Dictionary<string, TextMeshProUGUI>();

    void Awake()
    {
        _countryParameters = new Dictionary<string, Parameter>
        {
            //{GLOBAL_TAGS.POLLUTION_PARAM_TAG, Resources.Load<Parameter>("Parameters/Pollution")},
            {GLOBAL_TAGS.HAPPINESS_PARAM_TAG, Resources.Load<Parameter>("Parameters/Happines")},
            {GLOBAL_TAGS.INTEREST_IN_POLITICS_PARAM_TAG, Resources.Load<Parameter>("Parameters/Interest_in_politics")},
            {GLOBAL_TAGS.STABILITY_PARAM_TAG, Resources.Load<Parameter>("Parameters/Stability")},
            {GLOBAL_TAGS.WAR_SUPPORT_PARAM_TAG, Resources.Load<Parameter>("Parameters/War_support")},
        };

        int i = 0;
        foreach (var param in _countryParameters)
        {
            GameObject parameterDisplay = Instantiate(parameterDisplayPrefab, transform);
            parameterDisplay.GetComponentInChildren<TextMeshProUGUI>().text = "0%";
            parameterDisplay.GetComponentInChildren<Image>().overrideSprite = param.Value.Icon;
            parameterDisplay.GetComponent<RectTransform>().anchoredPosition =  new Vector2(45 + i * 110f, 0);
            _parameterDisplays.Add(param.Key, parameterDisplay.GetComponentInChildren<TextMeshProUGUI>());
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

    public void Display(Dictionary<Parameter, float> parameters)
    {
        foreach (var param in parameters)
        {
            string tag = param.Key.Tag;
            if (_parameterDisplays.ContainsKey(tag))
                _parameterDisplays[tag].text = Mathf.RoundToInt(param.Value * 100f) + "%";
        }      
    }
}
