using UnityEngine;

public class GlobalAction : MonoBehaviour
{
    private static CountryManager _countryManager;
    private Country _country;

    public int polCost = 0;
    public int milCost = 0;
    public int ecoCost = 0;
    
    public Effect effect;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _countryManager = CountryManager.GetInstance();
        _country = _countryManager.PlayerCountry;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnChoose()
    {
        if (_country.CountryResources["pol"].GetCount() >= polCost &&
            _country.CountryResources["mil"].GetCount() >= milCost &&
            _country.CountryResources["eco"].GetCount() >= ecoCost)
        {
            _country.CountryResources["pol"].IncreaseCount(-polCost);
            _country.CountryResources["mil"].IncreaseCount(-milCost);
            _country.CountryResources["eco"].IncreaseCount(-ecoCost);
            _country.ApplyEffect(effect);
            ResourceEvents.OnResourceGathered.Invoke("", 0);
            //GameManager.IncreaseWorldTension(0);
        }
    }
}
