using UnityEngine;
using UnityEngine.UI;

public class ActionPresenter : MonoBehaviour
{
    [SerializeField] private ActionModel model;
    [SerializeField] private ActionView view;
    private Action CurrentAction;

    private Region selectedRegion = null;

    private void OnEnable()
    {
        SelectionUIEvents.OnCellSelected.AddListener(HandleCellSelected);
        SelectionUIEvents.OnCellDeselected.AddListener(HandleCellDeselected);
        SelectionUIEvents.OnActionChosen.AddListener(HandleActionChosen);
        SelectionUIEvents.OnRegionSelected.AddListener(HandleRegionSelected);
        SelectionUIEvents.OnRegionParamsUpdated.AddListener(HandleRegionParamsUpdated);
    }

    private void OnDisable()
    {
        SelectionUIEvents.OnCellSelected.RemoveListener(HandleCellSelected);
        SelectionUIEvents.OnCellDeselected.RemoveListener(HandleCellDeselected);
        SelectionUIEvents.OnActionChosen.RemoveListener(HandleActionChosen);
        SelectionUIEvents.OnRegionSelected.RemoveListener(HandleRegionSelected);
        SelectionUIEvents.OnRegionParamsUpdated.RemoveListener(HandleRegionParamsUpdated);
    }

    private void HandleRegionSelected(Region region)
    {
        if (CountryManager.CountryRegions["Poland"].Contains(region.ID))
            view.DisplayButtons(model.registry[0].Actions);
        else // Germany
            view.DisplayButtons(model.registry[1].Actions);
        view.DisplayParameters(region.Parameters);
        view.DisplayActionPanel();

        region.selected = true;
        selectedRegion = region;
    }

    private void HandleRegionParamsUpdated(Region region)
    {
        //view.UpdateParameters(region.Parameters);
        
        if (CountryManager.CountryRegions["Poland"].Contains(region.ID))
            view.DisplayButtons(model.registry[0].Actions);
        else // Germany
            view.DisplayButtons(model.registry[1].Actions);
        view.DisplayParameters(region.Parameters);
        //view.DisplayActionPanel();
    }

    private void HandleCellSelected()
    {

    }

    private void HandleCellDeselected()
    {
        view.HideActionPanel();
        selectedRegion.selected = false;
        selectedRegion = null;
    }
    
    private void HandleActionChosen(Action action)
    {
        model.HandleActionChosen(action);
        ResourceEvents.OnResourceGathered.Invoke("eco", 0);
        //action.Activate();
    }
    
}
