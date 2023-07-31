using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Items : ScriptableObject
{
    public string itemName = "";
    [HideInInspector] public int pointsAmount = 0;
    [HideInInspector] public float boostMultiplier = 1;
    [HideInInspector] public float duration = 0;
    [HideInInspector] public bool hasEffects;
    [HideInInspector] public EffectType effectType;
    [HideInInspector] public string tooltip = "";
    [HideInInspector] public Sprite icon;
    [HideInInspector] public int currency = 0;
    [HideInInspector] public int price = 0;
    public float spawningRate = 0;


    public virtual void ApplyPoints()
    {

        //Add-subtract points to score (score from another script + pointsAmount)
        ScoreHolder scoreHolder = FindObjectOfType<ScoreHolder>();

        scoreHolder.score += pointsAmount;

        scoreHolder.gold += currency;

        scoreHolder.gold -= price;

        //e.g. 0.5 half of the speed, 1 normal speed, 2 double of the speed


        //multiply buff or debuffed feature 


    }

    public enum EffectType
    {
        Default,
        CameraSpeed,
        JumpForceChange,
        MaxJumpsChange,
        PlayerSpeedChange,
        Mushroom

    }

    public string DefineContent()
    {
        string content = tooltip;
        return content;
    }


}
