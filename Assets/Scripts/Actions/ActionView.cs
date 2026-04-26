using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionView : MonoBehaviour
{
    [SerializeField] private GameObject actionPanel;
    [SerializeField] private Button buttonPrefab;
    private Button[] buttons;

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
        foreach (Transform child in actionPanel.transform)
            Destroy(child.gameObject);
        
        foreach (var action in actions)
        {
            Button button = Instantiate(buttonPrefab, actionPanel.transform);
            Debug.Log($"Instantiated button for {action.Description}, parent: {button.transform.parent.name}");
            button.GetComponentInChildren<TMP_Text>().text = action.Description;
            button.onClick.AddListener(() => SelectAction(action));
        }
    }
}
