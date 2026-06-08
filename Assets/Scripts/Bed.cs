using UnityEngine;

public class Bed : MonoBehaviour
{
// How much HP the player loses when they interact with this bed
    public int hpDamage = 10;

    void OnCollisionEnter(Collision collision)
    {
        // Check if the thing that touched the bed has a Player script on it
        Player playerScript = collision.gameObject.GetComponent<Player>();

        if (playerScript != null)
        {
            // Subtract HP directly from the player
            playerScript.currentHP -= hpDamage;
            
            Debug.Log("Ouch! You touched the uncomfortable bed. Current HP: " + playerScript.currentHP);

            if (playerScript.currentHP <= 0)
            {
                Debug.Log("💀 Game Over! You ran out of HP.");
            }
        }
    }
}

