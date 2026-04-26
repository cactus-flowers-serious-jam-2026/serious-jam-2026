using System.Collections.Generic;
using UnityEngine;

public static class ResourcesDatabase
{
    public static Parameter[] parameters = Resources.LoadAll<Parameter>("Parameters");
    
    public static Sprite ECOLOGY_RES_SPRITE = Resources.Load<Sprite>("CountryResources/Ecological");
    public static Sprite MILITARY_RES_SPRITE = Resources.Load<Sprite>("CountryResources/Military");
    public static Sprite POLITICAL_RES_SPRITE = Resources.Load<Sprite>("CountryResources/Political");

    public static Dictionary<string, Sprite> TAG_SPRITE_MAP = new Dictionary<string, Sprite>()
    {
        { GLOBAL_TAGS.ECOLOGY_RES_TAG, ECOLOGY_RES_SPRITE },
        { GLOBAL_TAGS.MILITARY_RES_TAG, MILITARY_RES_SPRITE },
        { GLOBAL_TAGS.POLITICAL_RES_TAG, POLITICAL_RES_SPRITE },
    };
}
