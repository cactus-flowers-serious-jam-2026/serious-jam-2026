using Events;
using UnityEngine;

public class CountryParamPresenter : MonoBehaviour
{
    private Country PlayerCountry;
    [SerializeField]
    private CountryParamView _paramView;

    void Awake()
    {
        //PlayerCountry = CountryManager.instance.PlayerCountry;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerCountry = CountryManager.instance.PlayerCountry;
        ParameterEvents.ParametersChanged.AddListener(OnParametersChanged);
        OnParametersChanged();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParametersChanged()
    {
        if (PlayerCountry == null)
        {
            PlayerCountry = CountryManager.instance?.PlayerCountry;
            if (PlayerCountry == null) return;
        }
        _paramView.Display(PlayerCountry.parameters_temp);
    }
}
