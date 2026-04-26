using System;
using UnityEngine;

public class CountryResPresenter : MonoBehaviour
{
    public Country PlayerCountry;
    public CountryResView CountryResourceView;
    

    void Awake()
    {
        
    }

    private void OnEnable()
    {
        ResourceEvents.OnResourceGathered.AddListener(OnResourceCollected);
    }

    private void OnDisable()
    {
        ResourceEvents.OnResourceGathered.RemoveListener(OnResourceCollected);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CountryResourceView.Display(PlayerCountry.CountryResources);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnResourceCollected(string type, int count)
    {
        Debug.Log(PlayerCountry);
        Debug.Log(type + ": " + count);
        PlayerCountry.CollectResource(type, count);
        CountryResourceView.Display(PlayerCountry.CountryResources);
    }
}
