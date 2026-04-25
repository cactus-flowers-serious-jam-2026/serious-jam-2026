using UnityEngine;

public class CountryResPresenter : MonoBehaviour
{
    public Country PlayerCountry;
    public CountryResView CountryResourceView;
    

    void Awake()
    {
        
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CountryResourceView.Display(PlayerCountry.CountryResources);
        
        OnResourceGathered(GLOBAL_TAGS.ECOLOGY_RES_TAG, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnResourceGathered(string type, int count)
    {
        PlayerCountry.GatherResource(type, count);
        CountryResourceView.Display(PlayerCountry.CountryResources);
    }
}
