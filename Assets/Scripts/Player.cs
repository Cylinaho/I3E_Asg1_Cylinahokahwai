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

    public int currentHP = 100;
    public int TotalItemsCollected = 0;
    GameObject currentCollider;

    void Start()
    {
        startingPosition = transform.position;
        UPdateHP();
    }

    public void UPdateHP()
    {
        HPText.text = $"HP: {currentHP}";
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
                ScoreText.text = $"Keycards collected: {score} / {TotalItemsCollected}";

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

    // This is where we check for landing on the Clearbed, which will play a sound effect.
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Clearbed clearBedScript = hit.gameObject.GetComponent<Clearbed>();

        if (clearBedScript != null)
        {
            // The bed script will now handle filtering out the multiple rapid sounds
            clearBedScript.PlayLandingSound();
        }
    }
    public void Respawn()
    {
        CharacterController cc = GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        transform.position = startingPosition;

        if (cc != null) cc.enabled = true;

        print("Fell into the floor! Respawned back to start.");
    }
}