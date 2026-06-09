using UnityEngine;

public class Clearbed : MonoBehaviour
{
    // FIX: Changed Collider to Collision for physical collisions
    private void OnCollisionEnter(Collision collision)
    {
        // Make sure it's the player touching it
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Debug.Log("Player touched the clear bed!");

            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null) 
            {
                audioSource.Play();
            }
        }
    }
}