using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Items : ScriptableObject
{
    public string itemName = "";
    public int pointsAmount = 0;
    public float boostMultiplier = 1;
    public float buffDuration = 0;

    public virtual void TriggerEffect()
    {
        Debug.Log("Using " + itemName);

        //Add-subtract points to score (score from another script + pointsAmount)
        ScoreHolder scoreHolder = FindObjectOfType<ScoreHolder>();

        scoreHolder.score += pointsAmount;

        //e.g. 0.5 half of the speed, 1 normal speed, 2 double of the speed


        //multiply buff or debuffed feature 


    }



}
