using UnityEngine;

public class Clearbed : MonoBehaviour
{
    public AudioClip bedSound; 

    // This gets called directly by the Player script when they jump on it
    public void PlayLandingSound()
    {
        if (bedSound != null)
        {
            // PlayClipAtPoint creates a temporary audio player so the sound works cleanly
            AudioSource.PlayClipAtPoint(bedSound, transform.position);
            Debug.Log("🔊 Clearbed sound played successfully!");
        }
        else
        {
            Debug.LogWarning("⚠️ You jumped on the bed, but no AudioClip is assigned in the Inspector!");
        }
    }
}