using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target the camera will follow

    public Vector3 offset = new Vector3(0, 8, -8); // Offset from the target

    public float smoothSpeed = 10f; // Speed of the camera movement

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // Calculate the desired position of the camera

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime); // Smoothly move the camera to the desired position

        transform.LookAt(target); // Make the camera look at the target
    }
}