using UnityEngine;

[CreateAssetMenu(fileName = "ActionRegistry", menuName = "Scriptable Objects/ActionRegistry")]
public class ActionRegistry : ScriptableObject
{
    public Action[] Actions;
}
