using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActionModel : MonoBehaviour
{
    [SerializeField] public ActionRegistry[] registry;
    public Dictionary<String, Action> actions { get; private set; }
    
    [SerializeField] private HexModel hexModel;
    
    public Action CurrentAction { get; private set; }

    private void Awake()
    {
        //LoadActionsFromRegistry();
    }

    /*
    private void LoadActionsFromRegistry()
    {
        foreach (Action action in registry.Actions)
        {
            actions.Add(action.ActionID, action);
        }
    }
    */

    public void HandleActionChosen(Action action)
    {
        hexModel.HandleActionChosen(action);
    }
    
}
