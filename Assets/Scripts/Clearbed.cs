using UnityEngine;

public class Clearbed : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // This will print a message in your Console log the exact millisecond 
        // ANYTHING physically touches the bed.
        Debug.Log("Something physically hit the bed: " + collision.gameObject.name);

        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource == null) 
        {
            audioSource.Play();
        }
    }
}