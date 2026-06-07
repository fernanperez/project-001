using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target; // The target the camera will follow

    public Vector3 offset = new Vector3(0, 8, -8); // Offset from the target

    public float smoothSpeed = 10f; // Speed of the camera movement

    private void LateUpdate()
    {
        if (target == null)
        {
            PlayerController[] players = FindObjectsByType<PlayerController>();

            foreach (PlayerController player in players)
            {
                if (player.IsOwner)
                {
                    target = player.transform;
                    break;
                }
            }

            // Todavía no existe
            if (target == null)
                return;
        }

        Vector3 desiredPosition = target.position + offset; // Calculate the desired position of the camera

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime); // Smoothly move the camera to the desired position

        transform.LookAt(target); // Make the camera look at the target
    }
}