using UnityEngine;

public class Floordmg : MonoBehaviour
{
    // Automatically runs when the player physically hits the floor
    void OnCollisionEnter(Collision collision)
    {
        // Check if the thing hitting the floor is the player
        Player playerScript = collision.gameObject.GetComponent<Player>();

        if (playerScript != null)
        {
            // Tell the player script to teleport back to the start
            playerScript.Respawn();
        }
    }
}