using UnityEngine;

public class MovingPillow : MonoBehaviour
{
    public float moveDistance = 5f; 
    public float moveSpeed = 2f;          

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

    // When the player stands on the pillow, make them stick to it
    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.SetParent(transform);
    }

    // When the player jumps or walks off, let them go
    private void OnCollisionExit(Collision collision)
    {
        collision.transform.SetParent(null);
    }
}