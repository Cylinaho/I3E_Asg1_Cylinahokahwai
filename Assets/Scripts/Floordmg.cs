using UnityEngine;

public class Floordmg : MonoBehaviour
{
    // Automatically runs when the player physically hits the floor
    void OnTriggerEnter(Collider other)
    {
        Player playerScript = other.gameObject.GetComponent<Player>();

        if (playerScript != null)
        {
            // Now this function exists on the player again and will work!
            playerScript.Respawn();
        }
    }