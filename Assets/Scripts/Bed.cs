using UnityEngine;

public class Bed : MonoBehaviour
{
    public int hpDamage = 10;

    // CHANGED: Changed from OnCollisionEnter to OnTriggerEnter
    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the Player script
        Player playerScript = other.gameObject.GetComponent<Player>();

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
                // Optional: You could call playerScript.Respawn(); here too!
            }
        }
    }
}