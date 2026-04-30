using System.Collections.Generic;
using UnityEngine;

public static class ResourcesDatabase
{
    public static Parameter[] parameters = Resources.LoadAll<Parameter>("Parameters");
    
    public static string ECOLOGY_RES_SPRITEPATH = "CountryResources/Ecological";
    public static string MILITARY_RES_SPRITEPATH = "CountryResources/Military";
    public static string POLITICAL_RES_SPRITEPATH = "CountryResources/Political";
    
    public static string POLITICAL_POPUP_SPRITEPATH = "CountryResourcesPopups/Political";
    public static string MILITARY_POPUP_SPRITEPATH = "CountryResourcesPopups/Military";
    public static string ECOLOGY_POPUP_SPRITEPATH = "CountryResourcesPopups/Ecological";

    public static Dictionary<string, string> TAG_SPRITEPATH_MAP = new Dictionary<string, string>()
    {
        { GLOBAL_TAGS.ECOLOGY_RES_TAG, ECOLOGY_RES_SPRITEPATH },
        { GLOBAL_TAGS.MILITARY_RES_TAG, MILITARY_RES_SPRITEPATH },
        { GLOBAL_TAGS.POLITICAL_RES_TAG, POLITICAL_RES_SPRITEPATH },
    };
    
    public static Dictionary<string, string> TAG_POPUP_SPRITEPATH_MAP = new Dictionary<string, string>()
    {
        { GLOBAL_TAGS.ECOLOGY_RES_TAG, ECOLOGY_POPUP_SPRITEPATH },
        { GLOBAL_TAGS.MILITARY_RES_TAG, MILITARY_POPUP_SPRITEPATH },
        { GLOBAL_TAGS.POLITICAL_RES_TAG, POLITICAL_POPUP_SPRITEPATH },
    };
}
