using UnityEngine;

public class Bed : MonoBehaviour
{
    public int hpDamage = 10;

    void OnCollisionEnter(Collision collision)
    {
        // 1. Check if the thing that touched the bed is actually the Player
        Player playerScript = collision.gameObject.GetComponent<Player>();
        if (playerScript == null) return; // If it's not the player, stop here!

        // 2. Play the damage sound effect
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // 3. Deal damage and update the player's health UI
        playerScript.currentHP -= hpDamage;
        playerScript.UpdateHP(); 

        Debug.Log("Ouch! Touched the bed. Current HP: " + playerScript.currentHP);

        // 4. Handle player death if health drops to 0
        if (playerScript.currentHP <= 0)
        {
            Debug.Log("Game Over! Respawning...");
            playerScript.Respawn();
        }
    }
}