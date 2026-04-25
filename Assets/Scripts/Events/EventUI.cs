using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventUI : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject eventPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descText;
    public Image timerBar;

    [Header("Choice Buttons")]
    public GameObject[] choiceButtons;
    public TextMeshProUGUI[] buttonTexts;

    public EventPresenter presenter;

    void Start()
    {
        eventPanel.SetActive(false);
    }

    public void ShowEvent(GameEvent eventToShow)
    {
        titleText.text = eventToShow.eventTitle;
        descText.text = eventToShow.eventDescription;

        SetupButtons(eventToShow);

        eventPanel.SetActive(true);
    }

    public void UpdateTimerBar(float fillAmount)
    {
        timerBar.fillAmount = fillAmount;
    }

    public void HidePanel()
    {
        eventPanel.SetActive(false);
    }

    private void SetupButtons(GameEvent currentEvent)
    {
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            choiceButtons[i].SetActive(false);
        }

        for (int i = 0; i < currentEvent.buttonChoices.Length; i++)
        {
            if (i < choiceButtons.Length)
            {
                choiceButtons[i].SetActive(true);
                buttonTexts[i].text = currentEvent.buttonChoices[i];

                Button btn = choiceButtons[i].GetComponent<Button>();

                btn.onClick.RemoveAllListeners();

                int choiceIndex = i;

                btn.onClick.AddListener(() => presenter.OnOptionSelected(choiceIndex));
            }
        }
    }
}