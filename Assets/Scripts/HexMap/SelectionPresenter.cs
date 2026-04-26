using UnityEngine;
using UnityEngine.XR;

public class SelectionPresenter : MonoBehaviour
{
    [SerializeField] private HexModel model;
    [SerializeField] private SelectionView view;

    private void OnEnable()
    {
        SelectionUIEvents.OnCellSelected.AddListener(HandleCellSelected);
        SelectionUIEvents.OnCellDeselected.AddListener(HandleCellDeselected);

    }

    private void OnDisable()
    {
        SelectionUIEvents.OnCellSelected.RemoveListener(HandleCellSelected);
        SelectionUIEvents.OnCellDeselected.RemoveListener(HandleCellDeselected);
    }

    private void HandleCellSelected()
    {
        model.HandleSelection();
    }

    private void HandleCellDeselected()
    {
        model.HandleDeselection();
    }
}

