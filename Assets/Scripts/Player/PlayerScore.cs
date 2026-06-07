using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score = 0; // Player's score

    // Method to increase the player's score
    public void AddPoint()
    {
        score ++;
        Debug.Log("Puntaje: " + score);

        // Update the score display in the UI
        UIManager.Instance.UpdateScore(score);
    }
}