using UnityEngine;

public class CardCollectible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int cardID = 1; // Unique identifier for the card

    public void CollectCard()
    {
        var audioSource = GetComponent<AudioSource>();
        if (audioSource != null) audioSource.Play();

        Debug.Log("Collected card with ID: " + cardID);

        // Disable the collider immediately so the player can't interact twice
        if (GetComponent<Collider>() != null)
            GetComponent<Collider>().enabled = false;

        // Hide the game object's visuals safely
        var renderer = GetComponentInChildren<Renderer>();
        if (renderer != null) renderer.enabled = false;

        Destroy(gameObject, 1);
    }
}
