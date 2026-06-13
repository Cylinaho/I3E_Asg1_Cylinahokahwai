using UnityEngine;

public class Sticky : MonoBehaviour
{
    private CharacterController controller; // Reference to the player's CharacterController component
    private Vector3 lastPillowPosition; // To track the pillow's position from the last frame
    private Transform activePillow; // The pillow we're currently standing on, if any

    // This is called automatically by Unity when the object is first created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // This is called automatically by Unity after all Update() calls, ensuring the player has moved for the frame
    void LateUpdate()
    {
        // Shoot a quick raycast downward to see if the player is standing on the pillow
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f))
        {
            // Check if the thing player hit has a MovingPillow script on it
            MovingPillow pillow = hit.collider.GetComponent<MovingPillow>();

            if (pillow != null)
            {
                // If player just landed on it, grab its current position
                if (activePillow != pillow.transform)
                {
                    activePillow = pillow.transform;
                    lastPillowPosition = activePillow.position;
                }

                // Calculate how much the pillow moved since the last frame
                Vector3 pillowMovement = activePillow.position - lastPillowPosition;

                // Force the player controller to move that exact same amount
                controller.Move(pillowMovement);

                // Remember the pillow's position for the next frame
                lastPillowPosition = activePillow.position;
                return;
            }
        }

        // If player jumps or steps off the pillow, forget it
        activePillow = null;
    }
}