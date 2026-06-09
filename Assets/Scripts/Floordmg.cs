using UnityEngine;

public class Floordmg : MonoBehaviour
{
    // Automatically runs when the player physically hits the floor
    void OnTriggerEnter(Collider other)
    {
        Player playerScript = other.gameObject.GetComponent<Player>();

        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }

        if (playerScript != null)
        {
            // Now this function exists on the player again and will work!
            playerScript.Respawn();
        }
    }
}