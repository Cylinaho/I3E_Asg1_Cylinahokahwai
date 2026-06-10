using UnityEngine;

public class MovingPillow : MonoBehaviour
{
    public float moveDistance = 5f; // Distance the pillow will move back and forth 
    public float moveSpeed = 2f;    // Speed of the movement 

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        float factor = Mathf.PingPong(Time.time * moveSpeed, 1f);
        transform.position = Vector3.Lerp(startPosition, startPosition + (Vector3.forward * moveDistance), factor);
    }

    // When the player lands on the pillow
    private void OnCollisionEnter(Collision collision)
    {
        // Make sure your player GameObject has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Sets the player's parent to this moving pillow
            collision.transform.SetParent(transform);
        }
    }

    // When the player leaves the pillow
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Removes the parent so the player can move freely again
            collision.transform.SetParent(null);
        }
    }
}