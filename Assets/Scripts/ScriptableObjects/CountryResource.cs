using UnityEngine;

[CreateAssetMenu(fileName = "CountryResource", menuName = "Scriptable Objects/CountryResource")]
public class CountryResource : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    
    [SerializeField]
    private int Count;
    [SerializeField]
    private int MaxCount = 200;

    public void IncreaseCount(int x)
    {
        if (Count + x > MaxCount)
            Count = MaxCount;
        else
            Count += x;
    }

    public void SetCount(int x)
    {
        Count = x;
        if(Count > MaxCount)
            Count = MaxCount;
    }

    public int GetCount()
    {
        return Count;
    }
}
