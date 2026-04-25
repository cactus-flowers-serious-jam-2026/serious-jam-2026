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
    }

    private void OnDisable()
    {
        SelectionUIEvents.OnCellSelected.RemoveListener(HandleCellSelected);
        SelectionUIEvents.OnCellDeselected.RemoveListener(HandleCellDeselected);
        SelectionUIEvents.OnActionChosen.RemoveListener(HandleActionChosen);
    }
    

    private void HandleCellSelected()
    {
        view.DisplayButtons(model.registry.Actions);
        view.DisplayActionPanel();
    }

    private void HandleCellDeselected()
    {
        view.HideActionPanel();
    }
    
    private void HandleActionChosen(Action action)
    {
        action.Activate();
    }
    
}
