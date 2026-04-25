using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ParameterChange
{
    public Parameter parameter;
    public float change;
}

[System.Serializable]
public class ParameterChangeList
{
    public ParameterChange[] Changes;
}

[CreateAssetMenu(fileName = "Effect", menuName = "Scriptable Objects/Effect")]
public class Effect : ScriptableObject
{
    public string CountryId;
    public ParameterChangeList[] ParameterChanges;
}

