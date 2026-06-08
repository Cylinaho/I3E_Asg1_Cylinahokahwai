using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int score = 0; // Player's score

    public int TotalItemsCollected = 0; // Total items collected by the player

    GameObject currentCollider; // Reference to the current collectible item

    void OnTriggerEnter(Collider other)
    {
        currentCollider = other.gameObject;
    }

    void OnTriggerExit(Collider other)
    {
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
                    print("🏆 You collected all items! You win!");
                }

                collectible.CollectCard();
                currentCollider = null; // Clear this so we don't click it twice
                return; // Exit here so we don't check for doors on a dead object
            }
        }
    }
}
