using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float lifetime = 1f; // Time in seconds before the game object is destroyed

    private void Start()
    {
        Destroy(gameObject, lifetime); // Schedule the destruction of the game object after the specified lifetime
    }
}