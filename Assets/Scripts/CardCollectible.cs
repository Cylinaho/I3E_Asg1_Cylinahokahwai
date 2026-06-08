using UnityEngine;

public class CardCollectible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int cardID = 1; // Unique identifier for the card

    public void CollectCard()
    {
        var audioSource = GetComponent<AudioSource>();
        audioSource.Play(); // Play the card collection sound
        // Logic to add the card to the player's collection
        Debug.Log("Collected card with ID: " + cardID);
        // You can add code here to update the player's collection, UI, etc.

        // Destory game object after the sound effect has finished playing
        var renderer = GetComponent<Renderer>();
        renderer.enabled = false;

        Destroy(gameObject, 1); // Remove the collectible from the scene
    }
}
