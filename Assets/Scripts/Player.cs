using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    int score = 0;
    Vector3 startingPosition;

    public TMP_Text ScoreText;
    public TMP_Text HPText;
    public TMP_Text NoteText;

    public int maxHP = 100; // <-- ADDED THIS: Unity needs to know what maxHP is!
    public int currentHP = 100;
    public int TotalItemsCollected = 0;

    public SecurityDoor exitDoor; // Drag your door into this slot in the Unity Inspector!

    GameObject currentCollider;

    void Start()
    {
        startingPosition = transform.position;
        UPdateHP();
    }

    public void UPdateHP()
    {
        // 1. Clamp the math safely
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        
        // 2. Update the UI text
        if (HPText != null)
        {
            HPText.text = "HP: " + currentHP;
        }
    }

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

            var collectible = currentCollider.GetComponent<CardCollectible>();
            if (collectible != null)
            {
                score += collectible.cardID;
                print($"★ Item Collected! Current Score: {score} / {TotalItemsCollected}");
                ScoreText.text = $"Keycards collected: {score} / {TotalItemsCollected}";

                if (score >= TotalItemsCollected)
                {
                    print(" You collected all items! You win!");
                }

                collectible.CollectCard();
                currentCollider = null;
                return;
            }

            var securityDoor = currentCollider.GetComponent<SecurityDoor>();
            if (securityDoor != null)
            {
                securityDoor.Interact(this);
                return;
            }

            var door = currentCollider.GetComponent<Door>();
            if (door != null)
            {
                door.Interact();
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Clearbed clearBedScript = hit.gameObject.GetComponent<Clearbed>();
        if (clearBedScript != null)
        {
            clearBedScript.PlayLandingSound();
        }
    }

    public void Respawn()
    {
        CharacterController cc = GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        transform.position = startingPosition;

        if (cc != null) cc.enabled = true;

        // FIXED: Reset HP back to full when respawning, and update the text!
        currentHP = maxHP;
        UPdateHP();

        print("Fell into the floor! Respawned back to start.");
    }
}