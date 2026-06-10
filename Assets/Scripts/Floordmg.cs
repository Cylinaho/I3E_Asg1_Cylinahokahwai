using UnityEngine;

// This forces Unity to automatically add an AudioSource component to this object
[RequireComponent(typeof(AudioSource))]
public class Floordmg : MonoBehaviour
{
    private AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
        Player playerScript = other.gameObject.GetComponent<Player>();

        if (playerScript != null)
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