using UnityEngine;

public class Clearbed : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Something physically hit the bed: " + collision.gameObject.name);

        AudioSource audioSource = GetComponent<AudioSource>();
        
        // FIXED: Changed '== null' to '!= null' so it actually plays when found!
        if (audioSource != null) 
        {
            audioSource.Play();
        }
    }
}