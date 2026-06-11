using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    // Player Stats
    int score = 0;
    public int maxHP = 100;
    public int currentHP = 100;
    public int TotalItemsCollected = 0;

    // Movement & Spawn
    Vector3 startingPosition;
    CharacterController characterController;

    // UI Elements
    public TMP_Text ScoreText;
    public TMP_Text HPText;

    // World Objects
    public SecurityDoor exitDoor;
    GameObject currentCollider;

    void Start()
    {
        startingPosition = transform.position;
        characterController = GetComponent<CharacterController>();
        UpdateHP();
    }

    public void UpdateHP()
    {
        // Keep HP between 0 and maxHP
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        
        if (HPText != null)
        {
            HPText.text = "HP: " + currentHP;
        }
    }

    // Detect when standing near an item or door
    void OnTriggerEnter(Collider other)
    {
        currentCollider = other.gameObject;

        // If the player lands on a "Clearbed", play the sound immediately
        Clearbed clearBedScript = other.GetComponent<Clearbed>();
        if (clearBedScript != null)
        {
            clearBedScript.PlayLandingSound();
        }
    }

    // Detect when walking away from an item or door
    void OnTriggerExit(Collider other)
    {
        if (currentCollider == other.gameObject)
        {
            currentCollider = null;
        }
    }

    // Called when the player presses the Interact button
    void OnInteract(InputValue value)
    {
        // Do nothing if we aren't standing near anything
        if (currentCollider == null) return;

        // 1. Check if it's a Card Collectible
        CardCollectible collectible = currentCollider.GetComponent<CardCollectible>();
        if (collectible != null)
        {
            score = score + 1; 
            ScoreText.text = "Keycards collected: " + score + " / " + TotalItemsCollected;

            // Check if win condition is met
            if (score >= TotalItemsCollected && exitDoor != null)
            {
                exitDoor.ForceOpenDoor();
            }

            collectible.CollectCard();
            currentCollider = null;
            return;
        }

        // 2. Check if it's a normal Door
        Door door = currentCollider.GetComponent<Door>();
        if (door != null)
        {
            door.Interact();
        }
    }

    public void Respawn()
    {
        // Temporarily turn off controller to move the player safely
        if (characterController != null) characterController.enabled = false;

        transform.position = startingPosition;

        if (characterController != null) characterController.enabled = true;

        // Reset HP
        currentHP = maxHP;
        UpdateHP();
    }
}