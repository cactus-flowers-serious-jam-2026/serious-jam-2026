using UnityEngine;

[CreateAssetMenu(fileName = "Parameter", menuName = "Scriptable Objects/Parameter")]
public class Parameter : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public string Tag;
}
