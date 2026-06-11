using UnityEngine;

public class SecurityDoor : MonoBehaviour
{
    private bool isOpen = false;
    private Animator animatorComponent;

    void Start()
    {
        animatorComponent = GetComponent<Animator>();
        if (animatorComponent == null)
        {
            animatorComponent = GetComponentInChildren<Animator>();
        }
    }

    // Called automatically by the Player script from anywhere on the map
    public void ForceOpenDoor()
    {
        if (isOpen) return; // Prevent triggering it multiple times

        isOpen = true;
        PlayAnimation();
        print("All items collected! Security Door is opening automatically.");
    }

    private void PlayAnimation()
    {
        if (animatorComponent != null)
        {
            animatorComponent.SetBool("isOpen", isOpen);
        }
        else
        {
            // Fallback safe-snap rotation if animator is missing
            transform.Rotate(new Vector3(0, 90, 0));
            Debug.LogWarning($"No Animator found on {gameObject.name}! Snapping open.", this);
        }
    }
}