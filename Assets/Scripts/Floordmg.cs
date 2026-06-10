using UnityEngine;

public class Floordmg : MonoBehaviour
{
    // Drag my death sound clip here in the Unity Inspector
    public AudioClip deathSound; 

    // Adjust this number in the Inspector (0.0 is silent, 5.0 is full volume)
    public float volume = 5.0f; 

    // Automatically runs when the player enters the floor trigger zone
    void OnTriggerEnter(Collider other)
    {
        Player playerScript = other.gameObject.GetComponent<Player>();

        if (playerScript != null)
        {
            // This ensures it doesn't cut out when the player teleports away!
            if (deathSound != null)
            {
                // The volume variable is passed in as the third argument here
                AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, volume);
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