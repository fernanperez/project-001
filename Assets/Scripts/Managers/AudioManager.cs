using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // Singleton instance for easy access from other scripts

    public AudioSource sfxSource; // AudioSource for sound effects

    public AudioSource musicSource; // AudioSource for background music

    public AudioClip coinPickup; // AudioClip for coin pickup sound effect

    private void Awake()
    {
        Instance = this; // Set the singleton instance
    }

    public void PlayCoinSound()
    {
        sfxSource.PlayOneShot(coinPickup); // Play the coin pickup sound effect
    }
}