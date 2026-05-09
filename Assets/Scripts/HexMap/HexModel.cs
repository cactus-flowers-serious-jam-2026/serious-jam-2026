using UnityEngine;
using UnityEngine.EventSystems;

public class HexModel : MonoBehaviour
{
    public HexGrid HexGrid;
    public GameObject SelectionHex;
    public Region HexCellRegion => hexCellRegion;
    
    [SerializeField] private Region hexCellRegion;

    [SerializeField] private Country PlayerCountry;
    
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
        position = HexGrid.transform.InverseTransformPoint(position); 
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        
        Debug.Log("touched at " + coordinates);
        SelectionHex.transform.localPosition = HexCoordinates.PositionFromCoordinates(coordinates);
        SelectionHex.SetActive(true);
        
        SelectedCell = HexGrid.GetCell(coordinates);
        Region region = SelectedCell.gameObject.GetComponent<Region>();
        Debug.Log("CLICKED ON REGION WITH ID:" + region.ID);
        if (region != null)
            SelectionUIEvents.OnRegionSelected?.Invoke(region);
    }

    public void HandleActionChosen(Action action) // DONT TOOUCH
    {
        foreach (var countryRes in PlayerCountry.CountryResources)
            foreach (var actionResCost in action.Cost)
                if (actionResCost.resourceTag == countryRes.Key)
                    if (actionResCost.cost > countryRes.Value.GetCount()) 
                    {
                        Debug.Log("Not enough resources for this action!");
                        return;
                    }
        
        foreach (var actionResCost in action.Cost)
            PlayerCountry.CountryResources[actionResCost.resourceTag].IncreaseCount(-actionResCost.cost);
        
        hexCellRegion = SelectedCell.gameObject.GetComponent<Region>();
        action.Activate();
        for (int i = 0; i < action.Effect.ParameterChanges.Length; i++)
            for(int j = 0; j < action.Effect.ParameterChanges[i].Changes.Length; j++)
                HexCellRegion.ApplyChange(action.Effect.ParameterChanges[i].Changes[j]);
    }
}
