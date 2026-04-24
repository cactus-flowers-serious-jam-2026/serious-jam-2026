using UnityEngine;

public static class HexMetrics
{
    // controls the size of hexagons (note: remember to change the SelectionHex scaling to OR*2 for sprite and OR * 0.8 for mask
    public const float OuterRadius = 1.0f;
    public const float InnerRadius = OuterRadius * 0.866025404f;
    
    public static Vector3[] CornersPointy = {
        new Vector3(0f, OuterRadius), // top corner
        new Vector3(InnerRadius, 0.5f * OuterRadius), // top-right
        new Vector3(InnerRadius, -0.5f * OuterRadius),
        new Vector3(0f, -OuterRadius),
        new Vector3(-InnerRadius, -0.5f * OuterRadius),
        new Vector3(-InnerRadius, 0.5f * OuterRadius),
        new Vector3(0f, OuterRadius),
    };
    
    public static Vector3[] CornersFlat = {
        new Vector3(-OuterRadius, 0f), // left-most corner
        new Vector3(-0.5f * OuterRadius, InnerRadius), // top-left
        new Vector3(0.5f * OuterRadius, InnerRadius),
        new Vector3(OuterRadius, 0f),
        new Vector3(0.5f * OuterRadius, -InnerRadius),
        new Vector3(-0.5f * OuterRadius, -InnerRadius),
        new Vector3(-OuterRadius, 0f),
    };
}
