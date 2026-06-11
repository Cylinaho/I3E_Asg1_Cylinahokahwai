using UnityEngine;

public class Bed : MonoBehaviour
{
    public int hpDamage = 10;

    void OnCollisionEnter(Collision collision)
    {
        Player playerScript = collision.gameObject.GetComponent<Player>();

        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }

        if (playerScript != null)
        {
            // Just apply the damage directly...
            playerScript.currentHP -= hpDamage;
            
            // ...because UPdateHP() will automatically clamp it to 0 and fix the UI text!
            playerScript.UPdateHP();

            Debug.Log("Ouch! You touched the uncomfortable bed. Current HP: " + playerScript.currentHP);

            if (playerScript.currentHP <= 0)
            {
                Debug.Log("Game Over! You ran out of HP.");
                playerScript.Respawn();
            }
        }
    }
}