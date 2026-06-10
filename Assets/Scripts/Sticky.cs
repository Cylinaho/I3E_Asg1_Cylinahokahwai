using UnityEngine;

public class Sticky : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 lastPillowPosition;
    private Transform activePillow;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void LateUpdate()
    {
        // Shoot a quick raycast downward to see if we are standing on the pillow
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f))
        {
            // Check if the object below us has the MovingPillow script
            MovingPillow pillow = hit.collider.GetComponent<MovingPillow>();

            if (pillow != null)
            {
                // If we just landed on it, grab its current position
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

        // If we jump or step off the pillow, forget it
        activePillow = null;
    }
}