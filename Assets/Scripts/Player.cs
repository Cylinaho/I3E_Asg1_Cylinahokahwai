using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    int score = 0; // Track the player's score (number of items collected)
    Vector3 startingPosition; // To remember where the player started so player can respawn there

    public TMP_Text ScoreText; // For displaying the score of collected items
    public TMP_Text HPText; // For displaying the player's health,

    public int maxHP = 100; // Unity needs to know what maxHP is!
    public int currentHP = 100; // Track the player's current health, which can change when they take damage
    public int TotalItemsCollected = 0; // For tracking how many items are in the level, so the player can check for win condition

    public SecurityDoor exitDoor; // Drag your door into this slot in the Unity Inspector!

    GameObject currentCollider; // For tracking what object the player is currently colliding with, so the player can interact with it when the player presses the interact button

    // Remember where the player started for respawning later
    void Start()
    {
        startingPosition = transform.position;
        UpdateHP();
    }

    public void UpdateHP()
    {
        // Explicitly check upper and lower bounds
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        else if (currentHP < 0)
        {
            currentHP = 0;
        }

        // Update the UI text
        if (HPText != null)
        {
            HPText.text = "HP: " + currentHP;
        }
    }

    // A simple getter function for the player's score, which can be called by other scripts if needed
    public int GetScore()
    {
        return score;
    }

    // These functions are called automatically by Unity when the player collides with something or enters/exits a trigger collider, and they track what object the player is currently colliding with for interaction purposes
    void OnCollisionEnter(Collision collision)
    {
        print($"BUMPED INTO: {collision.gameObject.name} via Collision");
        currentCollider = collision.gameObject;
    }

    // This is for trigger colliders, which are used for things like collectible items and doors, so the player can interact with them without needing to physically bump into them
    void OnTriggerEnter(Collider other)
    {
        print($"ENTERED: {other.gameObject.name} via Trigger");
        currentCollider = other.gameObject;
    }

    // This is called automatically by Unity when the player exits a trigger collider, and it clears the currentCollider variable if the player leaves the object they were interacting with
    void OnTriggerExit(Collider other)
    {
        print($"EXITED: {other.gameObject.name} via Trigger");
        if (currentCollider == other.gameObject)
            currentCollider = null;
    }

    // This function is called when the player interacts with the current collider, and it checks if the player is currently colliding with an interactable object (like a collectible item or a door) and responds accordingly
    void OnInteract(InputValue value)
    {
        if (currentCollider != null)
        {
            var collectible = currentCollider.GetComponent<CardCollectible>();
            if (collectible != null)
            {
                // Assuming cardID is 1 per card collected
                score += collectible.cardID;
                print($"All Items Collected! Current Score: {score} / {TotalItemsCollected}");
                ScoreText.text = $"Keycards collected: {score} / {TotalItemsCollected}";

                // Check if the player has collected all items, and if so, automatically open the exit door
                if (score >= TotalItemsCollected)
                {
                    print("You collected all items! Opening the exit door automatically!");
                    if (exitDoor != null)
                    {
                        exitDoor.ForceOpenDoor(); // Call the door's automatic unlock function
                    }
                }

                collectible.CollectCard();
                currentCollider = null;
                return;
            }

            // Normal manual doors can still use manual interaction if needed
            var door = currentCollider.GetComponent<Door>();
            if (door != null)
            {
                door.Interact();
            }
        }
    }

    // This is called automatically by Unity when the character controller hits a collider, and it checks if the player has landed on a clear bed to play the landing sound effect
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Clearbed clearBedScript = hit.gameObject.GetComponent<Clearbed>();
        if (clearBedScript != null)
        {
            clearBedScript.PlayLandingSound();
        }
    }

    // This is called automatically by the Floordmg script when the player takes damage from falling into the floor, and it respawns the player back to the starting position and resets their health
    public void Respawn()
    {
        CharacterController cc = GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        transform.position = startingPosition;

        if (cc != null) cc.enabled = true;

        // Reset HP back to full when respawning, and update the text!
        currentHP = maxHP;
        UpdateHP();

        print("Fell into the floor! Respawned back to start.");
    }
}