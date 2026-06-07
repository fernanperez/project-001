using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public SpawnPoint spawnPoint;

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

            if (spawnPoint != null)
            {
                spawnPoint.isOccupied = false; // Mark the spawn point as free
            }

            CoinSpawner.Instance.CoinCollected(); // Notify the CoinSpawner that a coin has been collected

            Destroy(gameObject); // Destroy the coin after collecting
        }
    }
}
