using UnityEngine;

public class SecurityDoor : MonoBehaviour
{
    [Header("Door Settings")]
    public Vector3 rotateAmount = new Vector3(0, 90, 0); // Rotation when opening
    public int requiredCards = 10; // Number of cards needed to open

    private bool isOpen = false;

    // This is the method the Player script will call
    public void Interact(Player player)
    {
        // If the door is already open, just close it like a normal door
        if (isOpen)
        {
            transform.Rotate(-rotateAmount);
            isOpen = false;
            print("🚪 Closing security door.");
            return;
        }

        // If it's closed, check if the player has enough score/cards
        // Note: We access the player's 'score' here. 
        if (player.CardID() >= requiredCards)
        {
            transform.Rotate(rotateAmount);
            isOpen = true;
            print("🔓 Access Granted! The final door opens.");
        }
        else
        {
            int missingCards = requiredCards - player.CardID();
            print($"🔒 Access Denied! You need {missingCards} more security cards.");
        }
    }
}