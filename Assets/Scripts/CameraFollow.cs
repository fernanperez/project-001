using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target the camera will follow

    public Vector3 offset = new Vector3(0, 8, -8); // Offset from the target

    private void LateUpdate()
    {
        transform.position =  target.position + offset; // Update the camera's position to follow the target

        transform.LookAt(target); // Make the camera look at the target
    }
}