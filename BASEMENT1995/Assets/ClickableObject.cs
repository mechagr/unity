using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public string itemName = "Item";
    [TextArea(5, 10)]
    public string itemDescription = "Description here...";

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
    }

    void OnMouseExit()
    {
        targetScale = originalScale;
    }

    void OnMouseDown()
    {
        if (LoreDisplay.Instance != null)
        {
            LoreDisplay.Instance.ShowLore(itemName, itemDescription);
        }
    }
}