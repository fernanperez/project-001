using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance of the GameManager

    public float matchTime = 60f; // Duration of the match in seconds

    public TMP_Text timerText; // Reference to the TextMeshPro text component for displaying the timer

    private bool gameEnded; // Flag to check if the game has ended

    public GameObject gameOverPanel; // Reference to the Game Over panel in the UI

    private void Awake()
    {
        Instance = this; // Set the singleton instance to this object
    }

    private void Update()
    {
        if (gameEnded)
            return;

        matchTime -= Time.deltaTime; // Decrease the match time by the time elapsed since the last frame

        // Update the timer text in the UI
        timerText.text =
            "Time: " +
            Mathf.Ceil(matchTime);

        if (matchTime <= 0f)
        {
            matchTime = 0f; // Ensure the match time does not go below zero
            EndGame(); // Call the method to end the game
        }
    }

    private void EndGame()
    {
        gameEnded = true;

        gameOverPanel.SetActive(true); // Show the Game Over panel
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(
            SceneManager
            .GetActiveScene()
            .buildIndex
        );
    }
}