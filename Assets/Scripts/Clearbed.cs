using UnityEngine;

public class Clearbed : MonoBehaviour
{
void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null) 
        {
            audioSource.Play();
        }
    }
}