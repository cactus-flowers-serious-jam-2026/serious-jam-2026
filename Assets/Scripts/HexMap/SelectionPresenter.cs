using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionPresenter : MonoBehaviour
{
    public HexGrid HexGrid;
    public GameObject SelectionHex;
    
    private HexCell SelectedCell;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) // IsPointerOverGameObject() only triggers on UI objects
        {
            HandleSelection();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            SelectionHex.SetActive(false);
            SelectedCell = null;
        }
    }
    
    void HandleSelection()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit)) {
            TouchCell(hit.point);
        }
    }
    
    void TouchCell (Vector3 position) {
        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        
        Debug.Log("touched at " + coordinates);
        SelectionHex.transform.localPosition = HexCoordinates.PositionFromCoordinates(coordinates);
        SelectionHex.SetActive(true);
        
        SelectedCell = HexGrid.GetCell(coordinates.X, coordinates.Y);
    }
}
