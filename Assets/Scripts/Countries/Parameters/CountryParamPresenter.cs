using Events;
using UnityEngine;

public class CountryParamPresenter : MonoBehaviour
{
    private Country PlayerCountry;
    [SerializeField]
    private CountryParamView _paramView;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerCountry = CountryManager.instance.PlayerCountry;
        ParameterEvents.ParametersChanged.AddListener(OnParametersChanged);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParametersChanged()
    {
        _paramView.Display(PlayerCountry.parameters);
    }
}
