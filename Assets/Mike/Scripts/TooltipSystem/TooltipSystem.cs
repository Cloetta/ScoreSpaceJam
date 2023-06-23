using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    public static TooltipSystem current;

    public Tooltip tooltip;


    public void Awake()
    {
        current = this;
    }

    public static void Show(string content)
    {
        current.tooltip.SetText(content);
        current.tooltip.gameObject.SetActive(true);
        
    }

    public static void Hide()
    {
        if (current.tooltip != null)
        {
            current.tooltip.gameObject.SetActive(false);
            
        }
        else
        {
            return;
        }
            
    }
}