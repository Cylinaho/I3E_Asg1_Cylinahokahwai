using UnityEngine;

public class SecurityDoor : MonoBehaviour
{
    [Header("Door Settings")]
    public Vector3 rotateAmount = new Vector3(0, 90, 0); 
    public int requiredCards = 10; 

    private bool isOpen = false;

    public void Interact(Player player)
    {
        if (isOpen)
        {
            transform.Rotate(-rotateAmount);
            isOpen = false;
            print("🚪 Closing security door.");
            return;
        }

        // FIXED: Changed player.CardID() to player.GetScore() to match your Player script
        if (player.GetScore() >= requiredCards)
        {
            transform.Rotate(rotateAmount);
            isOpen = true;
            print("🔓 Access Granted! The final door opens.");
        }
        else
        {
            int missingCards = requiredCards - player.GetScore();
            print($"🔒 Access Denied! You need {missingCards} more security cards.");
        }
    }
}