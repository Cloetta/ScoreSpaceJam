using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f; // Speed at which the smoke moves upwards
    private int targetScore;

    [SerializeField] private ScoreHolder scoreHolder;
    [SerializeField] private GameObject player;
    [SerializeField] private int pointsAmountEachDifficultyIncrease = 100; //Default, you can change it in the inspector: Everytime that amount of points are collected, the speed increases.
    [SerializeField] private float speedIncrease = 0.25f;


    private void Update()
    {

        if (scoreHolder.score >= targetScore)
        {
            moveSpeed += speedIncrease;

            Debug.Log(moveSpeed);

            targetScore += pointsAmountEachDifficultyIncrease;
        }

        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        // Move the smoke upwards based on the moveSpeed and the elapsed time since the last frame
        



    }
}
