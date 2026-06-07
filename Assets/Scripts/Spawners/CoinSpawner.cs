using UnityEngine;

public class CoinSpawner : MonoBehaviour
{

    public GameObject coinPrefab; // Prefab of the coin to spawn

    public int maxCoins = 5; // Maximum number of coins to spawn at a time

    public static CoinSpawner Instance; // Singleton instance for easy access from other scripts

    private int activeCoins; // Counter for the number of active coins in the scene

    public SpawnPoint[] spawnPointScripts; // Array of SpawnPoint scripts attached to the spawn points

    private void Awake()
    {
        Instance = this; // Set the singleton instance
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        SpawnCoins();
    }

    // Method to spawn coins at random spawn points
    private void SpawnCoins()
    {
        for (int i = 0; i < maxCoins; i++)
        {
            SpawnSingleCoin(); // Spawn a single coin until the maximum number of coins is reached
        }
    }

    public void CoinCollected()
    {
        activeCoins--; // Decrease the count of active coins when one is collected

        if (activeCoins < maxCoins)
        {
            SpawnSingleCoin(); // Spawn a new coin if the number of active coins is less than the maximum
        }
    }

    private void SpawnSingleCoin()
    {
        SpawnPoint point = GetFreeSpawnPoint(); // Get a free spawn point
        if (point == null)
            return; // If there are no free spawn points, exit the method

        GameObject coin = Instantiate(coinPrefab, point.transform.position, coinPrefab.transform.rotation); // Spawn a coin at the free spawn point

        Coin coinScript = coin.GetComponent<Coin>(); // Get the Coin script from the spawned coin

        coinScript.spawnPoint = point; // Set the spawn point reference in the Coin script

        point.isOccupied = true; // Mark the spawn point as occupied

        activeCoins++; // Increase the count of active coins
    }

    private SpawnPoint GetFreeSpawnPoint()
    {
        var freePoints = new System.Collections.Generic.List<SpawnPoint>(); // List to hold unoccupied spawn points

        foreach (var point in spawnPointScripts)
        {
            if (!point.isOccupied)
            {
                freePoints.Add(point); // Add unoccupied spawn points to the list
            }
        }

        if (freePoints.Count == 0)
            return null; // If there are no free spawn points, exit the method

        int randomIndex = Random.Range(0, freePoints.Count); // Get a random index for the free spawn points

        return freePoints[randomIndex]; // Return a random unoccupied spawn point
    }
}
