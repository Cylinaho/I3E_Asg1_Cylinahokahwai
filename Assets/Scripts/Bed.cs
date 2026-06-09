using UnityEngine;

public class Bed : MonoBehaviour
{
    public int hpDamage = 10;

    // Changed from OnTriggerEnter to OnCollisionEnter
    void OnCollisionEnter(Collision collision)
    {
        // Check if the object we collided with has the Player script
        Player playerScript = collision.gameObject.GetComponent<Player>();

        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }

        if (playerScript != null)
        {
            playerScript.currentHP -= hpDamage;
            Debug.Log("Ouch! You touched the uncomfortable bed. Current HP: " + playerScript.currentHP);

            if (playerScript.currentHP <= 0)
            {
                Debug.Log("💀 Game Over! You ran out of HP.");
                playerScript.Respawn(); // Triggers your respawn logic
            }
        }
    }
}