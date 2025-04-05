using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipUI : MonoBehaviour
{

    public static TooltipUI Instance
    {
        get; private set;
    }


    [SerializeField]
    private RectTransform canvasRect;

    private RectTransform bgRect;
    private TextMeshProUGUI tmp;
    private RectTransform rectTransform;

    private void Awake()
    {
        Instance = this;

        bgRect = transform.Find("BG").GetComponent<RectTransform>();
        tmp = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        rectTransform = transform.GetComponent<RectTransform>();
        
        HideTooltip();
    }

    private void Update()
    {
        rectTransform.anchoredPosition = Input.mousePosition / canvasRect.localScale.x;
    }

    private void SetText(string tooltip)
    {
        tmp.SetText(tooltip);
        tmp.ForceMeshUpdate();

        Vector2 txtSize = tmp.GetRenderedValues(false);
        Vector2 padding = new Vector2(16, 16);

        bgRect.sizeDelta = txtSize + padding;
    }

    public void ShowTooltip(string tooltip)
    {
        gameObject.SetActive(true);
        SetText(tooltip);
    }
    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    public void ShowTooltip_Static(string tooltip)
    {
        Instance.ShowTooltip(tooltip);
    }

    public void HideTooltip_Static()
    {
        Instance.HideTooltip();
    }
}
