using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    int score = 0; // Player's score
    Vector3 startingPosition; // To store the player's initial position for respawning

    public int currentHP = 100; // Player's current health points
    public int TotalItemsCollected = 0; // Total items collected by the player
    GameObject currentCollider; // Reference to the current collectible item

    void Start()
    {
        // Remember exactly where the player started the game
        startingPosition = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        print($"BUMPED INTO: {collision.gameObject.name} via Collision");
        currentCollider = collision.gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        print($"ENTERED: {other.gameObject.name} via Trigger");
        currentCollider = other.gameObject;
    }

    void OnTriggerExit(Collider other)
    {
        print($"EXITED: {other.gameObject.name} via Trigger");
        if (currentCollider == other.gameObject)
            currentCollider = null;
    }

    void OnInteract(InputValue value)
    {
        if (currentCollider != null)
        {
            print($"Interacting with {currentCollider.name}");
            
            // 1. Check for Collectibles
            var collectible = currentCollider.GetComponent<CardCollectible>();
            if (collectible != null)
            {
                score += collectible.cardID; // Assuming cardID represents the score value

                print($"★ Item Collected! Current Score: {score} / {TotalItemsCollected}");

                // Check if the player won
                if (score >= TotalItemsCollected)
                {
                    print(" You collected all items! You win!");
                }

                collectible.CollectCard();
                currentCollider = null; // Clear this so we don't click it twice
                return; // Exit here so we don't check for doors on a dead object
            } // <-- FIXED: Added this missing closing bracket!

            // 2. Check for Doors
            var door = currentCollider.GetComponent<Door>();
            if (door != null)
            {
                door.Interact();
            }
        }
    }

    // Function to reset the player's position
    public void Respawn()
    {
        CharacterController cc = GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        // Teleport back to your saved start position instead of hardcoded 0,0,0
        transform.position = startingPosition;

        if (cc != null) cc.enabled = true;

        print("🔄 Fell into the floor! Respawned back to start.");
    }
}