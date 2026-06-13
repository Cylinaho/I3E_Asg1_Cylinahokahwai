using UnityEngine;

// This forces Unity to automatically add an AudioSource component to this object
[RequireComponent(typeof(AudioSource))]
public class Floordmg : MonoBehaviour
{
    private AudioSource audioSource; // Add the AudioSource component for better performance

    // This is called automatically by Unity when the object is first created
    void OnTriggerEnter(Collider other)
    {
        Player playerScript = other.gameObject.GetComponent<Player>(); // Try to get the Player script from the object that entered the trigger

        if (playerScript != null)
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
            }
            else
            {
                Debug.LogWarning("No Audio Clip assigned directly inside the AudioSource component!");
            }

            // Teleport the player back to safety
            playerScript.Respawn();
        }
    }
}