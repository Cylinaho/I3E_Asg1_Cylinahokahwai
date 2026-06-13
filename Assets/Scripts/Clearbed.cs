using UnityEngine;

// This forces Unity to automatically add an AudioSource component to this object
[RequireComponent(typeof(AudioSource))]
public class Clearbed : MonoBehaviour
{
    private AudioSource audioSource; // Add the AudioSource component for better performance
    private bool canPlaySound = true; // Flag to control sound cooldown
    public float soundCooldown = 1.0f; // Time in seconds before the sound can play again

    public void PlayLandingSound()
    {
        // Only play if the cooldown is over
        if (canPlaySound)
        {
            // Try to get the AudioSource component if it hasn't been assigned yet
            if (audioSource == null)
            {
                audioSource = GetComponent<AudioSource>();
            }

            // Check if there is an audio clip assigned inside the AudioSource
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
                Debug.Log("🔊 Clearbed sound played once!");

                // Start the cooldown process
                canPlaySound = false;
                Invoke(nameof(ResetSoundCooldown), soundCooldown);
            }
            else
            {
                Debug.LogWarning("No Audio Clip assigned directly inside the AudioSource component on Clearbed!");
            }
        }
    }

    // This method resets the cooldown, allowing the sound to be played again
    private void ResetSoundCooldown()
    {
        canPlaySound = true;
    }
}