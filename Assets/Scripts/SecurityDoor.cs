using UnityEngine;

public class SecurityDoor : MonoBehaviour
{
    [Header("Door Settings")]
    public int requiredCards = 10; 

    private bool isOpen = false;
    private Animator animatorComponent;

    void Start()
    {
        // Automatically look for the animator on this object or its children
        animatorComponent = GetComponent<Animator>();
        if (animatorComponent == null)
        {
            animatorComponent = GetComponentInChildren<Animator>();
        }
    }

    // This gets called directly by the Player script when pressing the interact button
    public void Interact(Player player)
    {
        if (player == null) return;

        if (isOpen)
        {
            isOpen = false;
            PlayAnimation();
            print(" Doors closing security door.");
            return;
        }

        // Checks the player's public score against requirements
        if (player. >= requiredCards)
        {
            isOpen = true;
            PlayAnimation();
            print(" Access Granted! The final door opens.");
        }
        else
        {
            int missingCards = requiredCards - player.score;
            print($" Access Denied! You need {missingCards} more security cards.");
        }
    }

    private void PlayAnimation()
    {
        if (animatorComponent != null)
        {
            animatorComponent.SetBool("isOpen", isOpen);
        }
        else
        {
            if (isOpen) transform.Rotate(new Vector3(0, 90, 0));
            else transform.Rotate(new Vector3(0, -90, 0));
            
            Debug.LogWarning($"No Animator found on {gameObject.name}! Snapping instantly instead.", this);
        }
    }
}