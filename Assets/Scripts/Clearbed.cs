using UnityEngine;

// This forces Unity to automatically add an AudioSource component to this object
[RequireComponent(typeof(AudioSource))]
public class Clearbed : MonoBehaviour
{
    private AudioSource audioSource;
    private bool canPlaySound = true;
    public float soundCooldown = 1.0f; // Time in seconds before the sound can play again

    public void PlayLandingSound()
    {
        // Only play if the cooldown is over
        if (canPlaySound)
        {
            // Fetch the AudioSource component if we haven't already
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

    private void ResetSoundCooldown()
    {
        canPlaySound = true;
    }
}