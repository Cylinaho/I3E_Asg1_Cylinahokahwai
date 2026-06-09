using UnityEngine;

public class Clearbed : MonoBehaviour
{
    // CHANGED: Changed from OnCollisionEnter to OnTriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        // Make sure it's the player touching it
        if (other.GetComponent<Player>() != null)
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