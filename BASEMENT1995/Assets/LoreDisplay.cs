using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using static Unity.Collections.Unicode;
using static UnityEngine.UI.GridLayoutGroup;

public class LoreDisplay : MonoBehaviour
{
    public static LoreDisplay Instance;

    public GameObject lorePanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI bodyText;

    private CanvasGroup panelCanvasGroup;

    void Awake()
    {
        Instance = this;

        if (lorePanel != null)
        {
            panelCanvasGroup = lorePanel.GetComponent<CanvasGroup>();
            if (panelCanvasGroup == null)
            {
                panelCanvasGroup = lorePanel.AddComponent<CanvasGroup>();
            }
            HidePanel();
        }
    }

    public void ShowLore(string title, string body)
    {
        if (lorePanel == null || titleText == null || bodyText == null)
        {
            Debug.LogError("UI elements not assigned!");
            return;
        }

        titleText.text = title;
        bodyText.text = body;

        panelCanvasGroup.alpha = 1;
        panelCanvasGroup.interactable = true;
        panelCanvasGroup.blocksRaycasts = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseLore()
    {
        HidePanel();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void HidePanel()
    {
        if (panelCanvasGroup != null)
        {
            panelCanvasGroup.alpha = 0;
            panelCanvasGroup.interactable = false;
            panelCanvasGroup.blocksRaycasts = false;
        }
    }
}