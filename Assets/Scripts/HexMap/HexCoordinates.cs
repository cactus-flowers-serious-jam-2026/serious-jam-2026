using UnityEngine;

[System.Serializable]
public struct HexCoordinates
{
    [SerializeField] private int x, y;
    
    public int X
    {
        get { return x;}
    }

    public int Y { get {return y;} }
    
    public int Z {
        get {
            return -X - Y;
        }
    }

    public HexCoordinates (int x, int y) {
        this.x = x;
        this.y = y;
    }   
    
    public static HexCoordinates FromOffsetCoordinates (int x, int y) {
        return new HexCoordinates(x, y - x / 2);
    }
    
    public static HexCoordinates FromPosition (Vector3 position) {
        float x = position.x / (HexMetrics.OuterRadius * 1.5f);
        float y = (position.y / (HexMetrics.InnerRadius * 2f)) - (x * 0.5f);
        float z = -x - y;

        int iX = Mathf.RoundToInt(x);
        int iY = Mathf.RoundToInt(y);
        int iZ = Mathf.RoundToInt(z);

        if (iX + iY + iZ != 0) { // https://catlikecoding.com/unity/tutorials/hex-map/part-1/
            float dX = Mathf.Abs(x - iX);
            float dY = Mathf.Abs(y - iY);
            float dZ = Mathf.Abs(z - iZ);

            if (dX > dY && dX > dZ) {
                iX = -iY - iZ;
            }
            else if (dY > dX && dY > dZ) {
                iY = -iX - iZ;
            }
            //Debug.Log($"dX:{dX} dY:{dY} dZ:{dZ} | rounded: {iX},{iY},{iZ} | sum: {iX+iY+iZ}");
        }
        

        return new HexCoordinates(iX, iY);
    }

    public static Vector3 PositionFromCoordinates(HexCoordinates coordinates)
    {
        Vector3 position;
        position.x = coordinates.X * (HexMetrics.OuterRadius * 1.5f);
        position.y = (coordinates.Y + coordinates.X * 0.5f) * (HexMetrics.InnerRadius * 2f);
        position.z = 0f;
        return position;
    }

    public override string ToString () {
        return "(" + X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ")";
    }
}
