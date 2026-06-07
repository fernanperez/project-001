using UnityEngine;
using TMPro;
using System.Collections;

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

        StartCoroutine(AnimateScore()); // Start the score animation coroutine
    }

    public IEnumerator AnimateScore()
    {
        scoreText.transform.localScale = Vector3.one * 1.5f; // Enlarge the score text

        yield return new WaitForSeconds(0.20f); // Wait for a short duration

        scoreText.transform.localScale = Vector3.one; // Reset the score text scale
    }
}
