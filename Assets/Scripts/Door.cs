using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen = false; 

    // Changing this to public lets you manually drag the animator into the script slot!
    public Animator animatorComponent; 

    void Start()
    {
        // We remove GetComponent so Unity doesn't try to auto-find it
        if (animatorComponent == null)
        {
            Debug.LogError($"Please drag your Animator component into the slot on {gameObject.name}!", this);
        }
    }

    public void Interact()
    {
        isOpen = !isOpen; 
        
        if (animatorComponent != null)
        {
            animatorComponent.SetBool("isOpen", isOpen);
        }
    }
}