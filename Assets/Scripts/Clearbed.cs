using UnityEngine;

public class Clearbed : MonoBehaviour
{
    public AudioClip bedSound;

    private bool canPlaySound = true;
    public float soundCooldown = 1.0f; // Time in seconds before the sound can play again

    public void PlayLandingSound()
    {
        // Only play if the cooldown is over
        if (canPlaySound)
        {
            if (bedSound != null)
            {
                AudioSource.PlayClipAtPoint(bedSound, transform.position);
                Debug.Log("🔊 Clearbed sound played once!");

                // Start the cooldown process
                canPlaySound = false;
                Invoke(nameof(ResetSoundCooldown), soundCooldown);
            }
            else
            {
                Debug.LogWarning("⚠️ No AudioClip assigned to Clearbed!");
            }
        }
    }

    private void ResetSoundCooldown()
    {
        canPlaySound = true;
    }
}