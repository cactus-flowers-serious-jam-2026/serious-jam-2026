using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [Header("UI Connections")]
    public TextMeshProUGUI dialogueText;

    [Header("Scene Settings")]
    public string nextSceneName = "main";

    [Header("Story")]
    [TextArea(3, 5)]
    public string[] introLines;
    private int currentLineIndex = 0;

    [Header("Typewriter Settings")]
    public float typingSpeed = 0.03f;

    private bool isTyping = false;
    private Coroutine typingCoroutine;

    void Start()
    {
        dialogueText.text = "- ";
        ShowNextLine();
    }

    public void ShowNextLine()
    {
        if (isTyping)
        {
            if (typingCoroutine != null) StopCoroutine(typingCoroutine);

            dialogueText.text = introLines[currentLineIndex - 1].Trim();

            isTyping = false;
            return;
        }

        if (currentLineIndex < introLines.Length)
        {
            currentLineIndex++;
            typingCoroutine = StartCoroutine(TypeLine(introLines[currentLineIndex - 1].Trim()));
        }
        else
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    private IEnumerator TypeLine(string line)
    {
        isTyping = true;

        dialogueText.text = "- ";

        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;

            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }
}