using UnityEngine;
using UnityEngine.Events;

public static class ResourceEvents
{
    public static UnityEvent<string, int> OnResourceGathered = new UnityEvent<string, int>();
}
