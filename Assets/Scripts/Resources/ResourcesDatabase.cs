using System.Collections.Generic;
using UnityEngine;

public static class ResourcesDatabase
{
    public static Parameter[] parameters = Resources.LoadAll<Parameter>("Parameters");
    
    public static string ECOLOGY_RES_SPRITEPATH = "CountryResources/Ecological";
    public static string MILITARY_RES_SPRITEPATH = "CountryResources/Military";
    public static string POLITICAL_RES_SPRITEPATH = "CountryResources/Political";

    public static Dictionary<string, string> TAG_SPRITEPATH_MAP = new Dictionary<string, string>()
    {
        { GLOBAL_TAGS.ECOLOGY_RES_TAG, ECOLOGY_RES_SPRITEPATH },
        { GLOBAL_TAGS.MILITARY_RES_TAG, MILITARY_RES_SPRITEPATH },
        { GLOBAL_TAGS.POLITICAL_RES_TAG, POLITICAL_RES_SPRITEPATH },
    };
}
