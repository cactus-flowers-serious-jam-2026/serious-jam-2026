using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountryManager : MonoBehaviour
{
    public static Dictionary<string, Country> Countries { get; private set; } = new Dictionary<string, Country>();
    
    public static Dictionary<string, List<int> > CountryRegions { get; private set; } = new Dictionary<string, List<int>>(); 
    public static CountryManager instance { get; private set; }
    public Country PlayerCountry;
    
    public static bool Loaded { get; set; } = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnSceneLoaded;
        
        //Countries.Clear();
        //CountryRegions.Clear();

        //PlayerCountry = GameObject.FindGameObjectWithTag("Player").GetComponent<Country>();
        //Countries.TryAdd("Poland", PlayerCountry);

        //CountryRegions.TryAdd("Poland", Resources.Load<CountryRegions>("Regions/RegionsPL").id.ToList());
        //CountryRegions.TryAdd("Germany", Resources.Load<CountryRegions>("Regions/RegionsDE").id.ToList());
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"=== OnSceneLoaded: {scene.name} ===");
        Loaded = false;
        Countries.Clear();

        if (!CountryRegions.ContainsKey("Poland"))
            CountryRegions["Poland"] = Resources.Load<CountryRegions>("Regions/RegionsPL").id.ToList();
        if (!CountryRegions.ContainsKey("Germany"))
            CountryRegions["Germany"] = Resources.Load<CountryRegions>("Regions/RegionsDE").id.ToList();
        

        var allRegions = FindObjectsByType<Region>(FindObjectsSortMode.None);

        var playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj == null) return;

        PlayerCountry = playerObj.GetComponent<Country>();
        Countries["Poland"] = PlayerCountry;
        
        PlayerCountry.Initialize();

        Loaded = true;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //PlayerCountry = GameObject.FindGameObjectWithTag("Player").GetComponent<Country>();
        //Countries.TryAdd("Poland", PlayerCountry);
        //ResourceEvents.OnResourceGathered.AddListener(OnResourceCollected);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ApplyEffect(string countryId, Effect e)
    {
        if(Countries.ContainsKey(countryId))
            Countries[countryId].ApplyEffect(e);
    }

    public static CountryManager GetInstance()
    {
        return instance;
    }

    public Country GetPlayerCountry()
    {
        return PlayerCountry;
    }
    
    public void OnResourceCollected(string type, int count)
    {
        Debug.Log(type + "\t" + count);
        //PlayerCountry.CollectResource(type, count);
    }
}
