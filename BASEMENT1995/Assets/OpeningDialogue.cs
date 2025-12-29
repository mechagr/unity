using UnityEngine;
using TMPro;
using System.Collections;

public class OpeningDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    public float fadeTime = 0.5f;

    private int currentLine = 0;
    private CanvasGroup canvasGroup;
    private bool canAdvance = true;

    void Start()
    {
        canvasGroup = dialoguePanel.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = dialoguePanel.AddComponent<CanvasGroup>();
        }

        if (dialogueLines.Length > 0)
        {
            StartCoroutine(ShowNextLine());
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void Update()
    {
        if (canAdvance && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            StartCoroutine(ShowNextLine());
        }
    }

    IEnumerator ShowNextLine()
    {
        canAdvance = false;

        if (currentLine > 0)
        {
            yield return StartCoroutine(FadeOut());
        }

        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
            currentLine++;

            yield return StartCoroutine(FadeIn());
            canAdvance = true;
        }
        else
        {
            yield return StartCoroutine(FadeOut());
            dialoguePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    IEnumerator FadeIn()
    {
        float elapsed = 0f;
        while (elapsed < fadeTime)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsed / fadeTime);
            yield return null;
        }
        canvasGroup.alpha = 1f;
    }

    IEnumerator FadeOut()
    {
        float elapsed = 0f;
        while (elapsed < fadeTime)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsed / fadeTime);
            yield return null;
        }
        canvasGroup.alpha = 0f;
    }
}