using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

[CreateAssetMenu(fileName = "Action", menuName = "Scriptable Objects/Action")]
public class Action : ScriptableObject
{
    public string Description;
    public Effect Effect;
    public int Timeout; // -1 - means one-time action, 0 - no timeout, 1+ - timeout in ticks 
    public Dictionary<Parameter, int> Cost;
    public bool Active = true;
    private int timeoutCounter;
    public string ActionID;

    private void OnValidate()
    {
        #if UNITY_EDITOR
        ActionID = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
    
    public void OnTickEvent()
    {
        if (!Active && Timeout > 0)
        {
            timeoutCounter = Timeout + 1;
            if (timeoutCounter == Timeout)
                Active = true;
        }
    }

    public void Activate()
    {
        if(!Active)
            return;
        
        if(Timeout == -1)
            Active = false;
        
        else if (Timeout > 0)
        {
            Active = false;
            timeoutCounter = 0;
        }
    }
}
