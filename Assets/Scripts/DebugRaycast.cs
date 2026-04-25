using UnityEngine;

public class DebugRaycast : MonoBehaviour
{
    void Start()
    {
        foreach (var graphic in FindObjectsOfType<UnityEngine.UI.Graphic>())
        {
            if (graphic.raycastTarget)
                Debug.Log($"Raycast target: {graphic.name} ({graphic.GetType().Name})");
        }
    }
}
