using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{   
    public TextMeshProUGUI contentField;

    public LayoutElement layoutElement;


    public int characterWrapLimit;

    public RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetText(string content)
    {
        contentField.text = content;

        int contentLength = contentField.text.Length;

        layoutElement.enabled = (contentLength > characterWrapLimit) ? true : false;
    }

    private void Update()
    {
        int contentLength = contentField.text.Length;

        layoutElement.enabled = (contentLength > characterWrapLimit) ? true : false;

        Vector2 position = Input.mousePosition;

        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        rectTransform.pivot = new Vector2(pivotX, pivotY+0.5f);

        transform.position = position;
    }

    
}
