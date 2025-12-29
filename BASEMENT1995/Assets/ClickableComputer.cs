using UnityEngine;

public class ClickableComputer : MonoBehaviour
{
    public string itemName = "VINCE's PC";
    [TextArea(5, 10)]
    public string itemDescription = "[REDACTED] 1995\r\nI tried to shut it down by myself last week. Bad idea.\r\nSomething ripples whenever I do. Forward or back, I can't tell anymore.\r\nWe were the ones keeping it contained, and I chose to remove myself.\r\nConsequence was inevitable.\r\nShould've stayed. \r\nShould've kept trying.\r\nYou were right, Dee.\r\n- V.";

    public float hoverScale = 1.15f;
    public float scaleSpeed = 8f;

    private Vector3 originalScale;
    private Vector3 targetScale;

    void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);
    }

    void OnMouseEnter()
    {
        targetScale = originalScale * hoverScale;
        Debug.Log("Mouse entered: " + itemName);
    }

    void OnMouseExit()
    {
        targetScale = originalScale;
        Debug.Log("Mouse exited: " + itemName);
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked: " + itemName);
        if (LoreDisplay.Instance != null)
        {
            LoreDisplay.Instance.ShowLore(itemName, itemDescription);
        }
    }
}