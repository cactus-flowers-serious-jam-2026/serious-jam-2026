using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SelectionView : MonoBehaviour
{
    [SerializeField] private Sprite SelectionSprite;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) // IsPointerOverGameObject() only triggers on UI objects
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.CompareTag("HexMesh"))
            {
                SelectionUIEvents.OnCellSelected?.Invoke();
            }
        }
        else if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            SelectionUIEvents.OnCellDeselected?.Invoke();
        }
    }

}
