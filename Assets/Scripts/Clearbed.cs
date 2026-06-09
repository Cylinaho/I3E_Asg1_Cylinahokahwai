using UnityEngine;

public class Clearbed : MonoBehaviour
{
    // Drag your audio clip into this slot in the Unity Inspector
    public AudioClip bedSound; 

    private void OnCollisionEnter(Collision collision)
    {
        // Make sure it's the player touching it
        Player player = collision.gameObject.GetComponent<Player>();
        
        if (player != null)
        {
            Debug.Log("Player touched the clear bed!");

            // Play the sound at the bed's position. 
            // This creates an independent sound that won't cut out or glitch when you teleport!
            if (bedSound != null)
            {
                AudioSource.PlayClipAtPoint(bedSound, transform.position);
            }
        }
    }
}