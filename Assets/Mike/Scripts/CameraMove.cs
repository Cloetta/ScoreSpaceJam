using UnityEngine;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// An add-on module for Cinemachine Virtual Camera that locks the camera's Y co-ordinate
/// </summary>
[SaveDuringPlay]
[AddComponentMenu("")] // Hide in menu
public class CameraMove : CinemachineExtension
{
    public float moveSpeed = 1.0f; // Speed at which the camera moves upwards
    private int targetScore;

    private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private ScoreHolder scoreHolder;
    [SerializeField] private GameObject player;
    [SerializeField] private int pointsAmountEachDifficultyIncrease = 100; //Default, you can change it in the inspector: Everytime that amount of points are collected, the speed increases.
    [SerializeField] private float speedIncrease = 0.25f;

    //[Tooltip("Lock the camera's Y position to the value of the ")]
    //public float m_YPosition = 10;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Finalize)
        {
            var pos = state.RawPosition;
            pos.y = transform.position.y;
            state.RawPosition = pos;
        }
    }


    private void Start()
    {
        // Get the reference to the CinemachineVirtualCamera component attached to the same GameObject
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        targetScore = scoreHolder.score + pointsAmountEachDifficultyIncrease;

    }

    private void FixedUpdate()
    {
        //UpdatingCameraSpeedByScore();

        if (scoreHolder.score >= targetScore)
        {
            moveSpeed += speedIncrease;

            Debug.Log(moveSpeed);

            targetScore += pointsAmountEachDifficultyIncrease;
        }

        // Move the camera upwards based on the moveSpeed and the elapsed time since the last frame
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        Debug.Log(moveSpeed);
    }



    private void UpdateCameraSpeedByTime()
    {




    }
}