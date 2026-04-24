using TMPro;
using UnityEngine;

using UnityEngine.UI;

public class HexGrid : MonoBehaviour
{
    public int width = 6;
    public int height = 6;
    
    public HexCell cellPrefab;
    
    HexCell[,] cells;
    
    HexMesh hexMesh;

    void Awake()
    {
        hexMesh = GetComponentInChildren<HexMesh>();
        
        cells = new HexCell[width, height];
        
        for (int y = 0, i = 0; y < height; y++)
        for (int x = 0; x < width; x++)
            CreateCell(x, y, i++);
    }

    void CreateCell(int x, int y, int i)
    {
        Vector2 position;
        position.x = (x) * (HexMetrics.OuterRadius * 1.5f);
        position.y = (y + x * 0.5f - x / 2) * (HexMetrics.InnerRadius * 2f); // “odd-q” vertical layout (https://www.redblobgames.com/grids/hexagons/#basics)
        
        HexCell cell = cells[x,y] = Instantiate(cellPrefab, transform);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, y);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hexMesh.Triangulate(cells);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public HexCell GetCell(int x, int y)
    {
        return cells[x,y];
    }
}
