using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Speed of the player movement
    public float rotationSpeed = 5f; // Speed of the player rotation

    private Rigidbody rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Get input from the horizontal"X" and vertical"Z" axes
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Create a movement vector based on the input
        Vector3 movement = new Vector3(moveX, 0.0f, moveZ);

        // Apply the movement to the player's Rigidbody
        rb.AddForce(movement * speed);

        // Rotate the player based on the input
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
