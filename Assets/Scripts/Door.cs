using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen = false; 

    // This assigned in the inspector to the Animator component that controls the door's opening animation
    public Animator animatorComponent; 

    void Start()
    {
        // If the animator component wasn't assigned in the inspector, try to find it on this object or its children
        if (animatorComponent == null)
        {
            Debug.LogError($"Please drag your Animator component into the slot on {gameObject.name}!", this);
        }
    }


    // Called automatically by the Player script when the player interacts with this door
    public void Interact()
    {
        isOpen = !isOpen; 
        
        if (animatorComponent != null)
        {
            animatorComponent.SetBool("isOpen", isOpen);
        }
    }
}