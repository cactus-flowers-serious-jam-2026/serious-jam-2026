using System;
using System.Collections.Generic;
using UnityEngine;

public class ActionModel : MonoBehaviour
{
    [SerializeField] public ActionRegistry registry;
    public Dictionary<String, Action> actions { get; private set; }
    
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
        
    }
    
}
