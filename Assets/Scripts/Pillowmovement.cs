using UnityEngine;

public class MovingPillow : MonoBehaviour
{
    public float moveDistance = 5f; 
    public float moveSpeed = 2f;          

    private Vector3 startPosition;
    private Vector3 previousPosition;

    void Start()
    {
        startPosition = transform.position;
        previousPosition = transform.position;
    }

    void FixedUpdate()
    {
        // 1. Move the pillow
        float factor = Mathf.PingPong(Time.time * moveSpeed, 1f);
        transform.position = Vector3.Lerp(startPosition, startPosition + (Vector3.forward * moveDistance), factor);

        // 2. Calculate how much the pillow moved this frame
        Vector3 platformMovement = transform.position - previousPosition;

        // 3. Shoot a tiny raycast upwards to see if the player is standing on top
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.up, out hit, 2f))
        {
            // If the player is on top, drag them along with the pillow
            if (hit.collider.CompareTag("Player"))
            {
                hit.collider.transform.position += platformMovement;
            }
        }

        // Save the current position for the next frame
        previousPosition = transform.position;
    }
}