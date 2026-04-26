using UnityEngine;
using UnityEngine.Events;

public static class SelectionUIEvents
{
    public static UnityEvent OnCellSelected = new UnityEvent();
    public static UnityEvent OnCellDeselected = new UnityEvent();
    public static UnityEvent<Region> OnRegionSelected = new UnityEvent<Region>();
    public static UnityEvent<Action> OnActionChosen = new UnityEvent<Action>();
}
