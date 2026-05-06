using UnityEngine;
using UnityEngine.UI;

public class ActionPresenter : MonoBehaviour
{
    [SerializeField] private ActionModel model;
    [SerializeField] private ActionView view;
    private Action CurrentAction;

    private void OnEnable()
    {
        SelectionUIEvents.OnCellSelected.AddListener(HandleCellSelected);
        SelectionUIEvents.OnCellDeselected.AddListener(HandleCellDeselected);
        SelectionUIEvents.OnActionChosen.AddListener(HandleActionChosen);
        SelectionUIEvents.OnRegionSelected.AddListener(HandleRegionSelected);
    }

    private void OnDisable()
    {
        SelectionUIEvents.OnCellSelected.RemoveListener(HandleCellSelected);
        SelectionUIEvents.OnCellDeselected.RemoveListener(HandleCellDeselected);
        SelectionUIEvents.OnActionChosen.RemoveListener(HandleActionChosen);
        SelectionUIEvents.OnRegionSelected.RemoveListener(HandleRegionSelected);
    }

    private void HandleRegionSelected(Region region)
    {
        view.DisplayButtons(model.registry.Actions);
        view.DisplayParameters(region.Parameters);
        view.DisplayActionPanel();
    }
    

    private void HandleCellSelected()
    {

    }

    private void HandleCellDeselected()
    {
        view.HideActionPanel();
    }
    
    private void HandleActionChosen(Action action)
    {
        model.HandleActionChosen(action);
        //action.Activate();
    }
    
}
