using UnityEngine;
using Cinemachine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed = 1.0f; // Speed at which the camera moves upwards
    private CinemachineVirtualCamera virtualCamera;

    [SerializeField]
    private ScoreHolder scoreHolder;

    [SerializeField]
    private GameObject player;


    [SerializeField]
    private int pointsAmountEachDifficultyIncrease = 100; //Default, you can change it in the inspector: Everytime that amount of points are collected, the speed increases.
    [SerializeField]
    private float speedIncrease = 0.25f;

    private void Start()
    {
        // Get the reference to the CinemachineVirtualCamera component attached to the same GameObject
        virtualCamera = GetComponent<CinemachineVirtualCamera>();

    }

    private void Update()
    {
        // Move the camera upwards based on the moveSpeed and the elapsed time since the last frame
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);


        UpdatingCameraSpeedByScore();


    }

    private void UpdatingCameraSpeedByScore()
    {





    }

    private void UpdateCameraSpeedByTime()
    {




    }
}