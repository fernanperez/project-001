using System;
using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public SpawnPoint spawnPoint; // Reference to the spawn point where this coin was spawned

    private bool collected = false; // Flag to prevent multiple collections of the same coin

    public GameObject pickupEffect; // Particle effect to play when the coin is collected

    private void Start()
    {
        GetComponent<Collider>().enabled = false; // Disable the collider at the start to prevent immediate collection

        StartCoroutine(EnableColliderNextFrame()); // Enable the collider in the next frame to allow for collection
    }

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
        if (collected)
            return; // If the coin has already been collected, exit the method


        if (!other.CompareTag("Player")) return; // Check if the collider belongs to the player, if not, exit the method

        collected = true; // Mark the coin as collected to prevent multiple collections

        Collider coinCollider = GetComponent<Collider>(); // Get the Collider component of the coin

        if (coinCollider != null)
        {
            coinCollider.enabled = false; // Disable the collider to prevent further collisions
        }

        GameManager.Instance.AddScore(1); // Add 1 point to the player's score

        if (spawnPoint != null)
        {
            spawnPoint.isOccupied = false; // Mark the spawn point as free
        }

        CoinSpawner.Instance.CoinCollected(); // Notify the CoinSpawner that a coin has been collected

        AudioManager.Instance.PlayCoinSound(); // Play the coin pickup sound effect

        Instantiate(pickupEffect, transform.position, Quaternion.identity); // Spawn the pickup effect at the coin's position

        Destroy(gameObject); // Destroy the coin after collecting
    }

    private IEnumerator EnableColliderNextFrame()
    {
        yield return new WaitForFixedUpdate(); // Wait for the next fixed update to ensure that the coin has been fully processed before enabling the collider

        GetComponent<Collider>().enabled = true; // Enable the collider to allow for collisions with the player
    }
}
