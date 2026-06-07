using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance; // Singleton instance of the UIManager

    public TMP_Text scoreText; // Reference to the TextMeshPro text component for displaying the score


    private void Awake()
    {
        Instance = this; // Set the singleton instance to this object
    }

    public void UpdateScore(int score)
    {
        if (scoreText == null)
        {
            Debug.LogWarning("Score Text reference is missing in UIManager.");
            return;            
        }

        scoreText.text = "Score: " + score; // Update the score text in the UI
    }
}
