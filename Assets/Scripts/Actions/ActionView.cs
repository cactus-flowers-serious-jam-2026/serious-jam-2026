using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionView : MonoBehaviour
{
    [SerializeField] private GameObject actionPanel;
    [SerializeField] private Button buttonPrefab;
    private Button[] buttons;

    [SerializeField] private TMP_Text parameterEntryPrefab;
    [SerializeField] private GameObject parameterContainer;
    [SerializeField] private GameObject buttonContainer;

    private void Awake()
    {
        actionPanel.SetActive(false);
    }
    
    public void DisplayActionPanel()
    {
        Debug.Log("display action panel");
        actionPanel.SetActive(true);
    }

    public void HideActionPanel()
    {
        Debug.Log("hide action panel");
        actionPanel.SetActive(false);
    }

    public void SelectAction(Action action)
    {
        SelectionUIEvents.OnActionChosen?.Invoke(action);
        HideActionPanel();
        SelectionUIEvents.OnCellDeselected?.Invoke();
    }

    public void DisplayButtons(Action[] actions)
    {
        foreach (Transform child in buttonContainer.transform)
            Destroy(child.gameObject);
        
        foreach (var action in actions)
        {
            Button button = Instantiate(buttonPrefab, buttonContainer.transform);
            Debug.Log($"Instantiated button for {action.Description}, parent: {button.transform.parent.name}");
            button.GetComponentInChildren<TMP_Text>().text = action.Description;
            button.onClick.AddListener(() => SelectAction(action));
        }
    }
    
    public void DisplayParameters(Dictionary<Parameter, float> parameters)
    {
        foreach (Transform child in parameterContainer.transform)
            Destroy(child.gameObject);

        foreach (var kvp in parameters)
        {
            TMP_Text entry = Instantiate(parameterEntryPrefab, parameterContainer.transform);
            entry.text = $"{kvp.Key.name}: {(int)(kvp.Value * 100)}%";
            entry.color = new Color32(50, 50, 50, 255);
        }
    }
}
