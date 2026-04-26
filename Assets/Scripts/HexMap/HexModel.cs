using UnityEngine;
using UnityEngine.EventSystems;

public class HexModel : MonoBehaviour
{
    public HexGrid HexGrid;
    public GameObject SelectionHex;
    public Region HexCellRegion => hexCellRegion;
    
    [SerializeField] private Region hexCellRegion;
    
    
    
    public HexCell SelectedCell {  get; private set; }


    private void Awake()
    {
    }
    
    
    void Update()
    {

    }
    
    public void HandleSelection()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit)) {
            TouchCell(hit.point);
        }
    }

    public void HandleDeselection()
    {
        SelectionHex.SetActive(false);
    }
    
    void TouchCell (Vector3 position) {
        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        
        Debug.Log("touched at " + coordinates);
        SelectionHex.transform.localPosition = HexCoordinates.PositionFromCoordinates(coordinates);
        SelectionHex.SetActive(true);
        
        SelectedCell = HexGrid.GetCell(coordinates);
        Region region = SelectedCell.gameObject.GetComponent<Region>();
        if (region != null)
            SelectionUIEvents.OnRegionSelected?.Invoke(region);
    }

    public void HandleActionChosen(Action action) // DONT TOOUCH
    {
        hexCellRegion = SelectedCell.gameObject.GetComponent<Region>();
        Debug.Log("CLICKED ON REGION WITH ID:" + hexCellRegion.ID);
        action.Activate();
        for (int i = 0; i < action.Effect.ParameterChanges[HexCellRegion.ID].Changes.Length; i++)
        {
            HexCellRegion.ApplyChange(action.Effect.ParameterChanges[HexCellRegion.ID].Changes[i]);
        }
    }
}
