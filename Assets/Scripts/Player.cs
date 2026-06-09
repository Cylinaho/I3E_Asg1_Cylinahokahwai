using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    int score = 0; 
    Vector3 startingPosition; 

    public int currentHP = 100; 
    public int TotalItemsCollected = 0; 
    GameObject currentCollider; 

    void Start()
    {
        startingPosition = transform.position;
    }

    // Helper function so the Security Door can check your score
    public int GetScore()
    {
        return score;
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
                score += collectible.cardID; 
                print($"★ Item Collected! Current Score: {score} / {TotalItemsCollected}");

                if (score >= TotalItemsCollected)
                {
                    print(" You collected all items! You win!");
                }

                collectible.CollectCard();
                currentCollider = null; 
                return; 
            } 

            // 2. Check for Security Doors
            var securityDoor = currentCollider.GetComponent<SecurityDoor>();
            if (securityDoor != null)
            {
                securityDoor.Interact(this); 
                return;
            }

            // 3. Check for Normal Doors
            var door = currentCollider.GetComponent<Door>();
            if (door != null)
            {
                door.Interact();
            }
        }
    }

    public void Respawn()
    {
        CharacterController cc = GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        transform.position = startingPosition;

        if (cc != null) cc.enabled = true;

        print("🔄 Fell into the floor! Respawned back to start.");
    }
}