using Unity.Netcode;
using UnityEngine;

public class ConnectionManager : MonoBehaviour
{
    public GameObject connectionPanel;

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();

        connectionPanel.SetActive(false);

        Debug.Log("HOST iniciado");

        CoinSpawner.Instance.SpawnCoinsServer(); // Spawn coins at the start of the game when the host starts
    }

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();

        connectionPanel.SetActive(false);

        Debug.Log("CLIENT conectado");
    }
}