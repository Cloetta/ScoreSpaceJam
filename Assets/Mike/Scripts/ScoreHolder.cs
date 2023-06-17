using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreHolder : MonoBehaviour
{
    public int score = 0;

    [SerializeField]
    TextMeshProUGUI inGameScore, finalScore;


    void Start()
    {
        score = 0;
    }

    void Update()
    {
        inGameScore.text = score.ToString();
        finalScore.text = score.ToString();

    }

}

