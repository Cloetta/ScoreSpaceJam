using UnityEngine;
using Cinemachine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed = 1.0f; // Speed at which the camera moves upwards
    private CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        // Get the reference to the CinemachineVirtualCamera component attached to the same GameObject
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        // Move the camera upwards based on the moveSpeed and the elapsed time since the last frame
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}