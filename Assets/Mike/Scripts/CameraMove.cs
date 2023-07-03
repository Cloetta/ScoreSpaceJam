using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed = 1.0f; //Speed at which the camera moves upwards
    private int targetScore;
    [SerializeField] private ScoreHolder scoreHolder;
    [SerializeField] private GameObject player;
    [SerializeField] private int pointsAmountEachDifficultyIncrease = 100; //Default, you can change it in the inspector: Everytime that amount of points are collected, the speed increases.
    [SerializeField] private float speedIncrease = 0.25f;
    [SerializeField] private float distanceToCameraTop = 2f;


    private float cameraTopPosition;
    public float cameraOffset = 2f;
    private bool shouldFollowPlayer;

    private void Start()
    {
        //Get the reference to the CinemachineVirtualCamera component attached to the same GameObject
        targetScore = scoreHolder.score + pointsAmountEachDifficultyIncrease;
        
    }

    private void Update()
    {

        if (scoreHolder.score >= targetScore)
        {
            moveSpeed += speedIncrease;

            Debug.Log(moveSpeed);

            targetScore += pointsAmountEachDifficultyIncrease;
        }

        cameraTopPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;

        //Move the camera upwards
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        //Calculate the target Y position for the camera
        float targetY = player.transform.position.y + cameraOffset;

        // If the player is above the camera's current Y position
        if (player.transform.position.y > cameraTopPosition - distanceToCameraTop)
        {
            shouldFollowPlayer = true;
        }

        //If the flag is set, lerp the camera's position to catch up with the player
        if (shouldFollowPlayer)
        {
            Vector3 targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, 15 * Time.deltaTime);

            //Check if the camera has reached or surpassed the target position
            if (transform.position.y >= targetY)
            {
                shouldFollowPlayer = false;
            }
        }
       
    }

    //aaa

}