using UnityEngine;

public class Coin : MonoBehaviour
{
    // Update is called once per frame, used here to rotate the coin for visual effect
    private void Update() 
    {
        transform.Rotate(
            Vector3.forward,
            100f * Time.deltaTime
        );
    }

    // Method called when another collider enters the trigger collider attached to the coin
    private void OnTriggerEnter(Collider other)
    {
        PlayerScore score = other.GetComponent<PlayerScore>();

        if (score != null)
        {
            score.AddPoint(); // Increase the player's score
            Destroy(gameObject); // Destroy the coin after collecting
        }
    }
}
