using UnityEngine;

public class Floordmg : MonoBehaviour
{
    // Drag your death sound clip here in the Unity Inspector
    public AudioClip deathSound; 

    // Automatically runs when the player enters the floor trigger zone
    void OnTriggerEnter(Collider other)
    {
        Player playerScript = other.gameObject.GetComponent<Player>();

        if (playerScript != null)
        {
            // FIX: Play the audio at the position where the player fell.
            // This ensures it doesn't cut out when the player teleports away!
            if (deathSound != null)
            {
                AudioSource.PlayClipAtPoint(deathSound, other.transform.position);
            }
            else
            {
                Debug.LogWarning("No Death Sound assigned to Floordmg component!");
            }

            // Teleport the player back to safety
            playerScript.Respawn();
        }
    }
}