using UnityEngine;

public class MovingPillow : MonoBehaviour
{
    public float moveDistance = 5f; // How far the pillow moves back and forth
    public float moveSpeed = 2f;    // How fast the pillow moves      
    private Vector3 startPosition; // To remember where the pillow started so player can move relative to that

    // This is called automatically by Unity when the object is first created
    void Start()
    {
        startPosition = transform.position;
    }

    
    // This is called automatically by Unity at a fixed interval, which is ideal for smooth movement that isn't affected by frame rate
    void FixedUpdate()
    {
        float factor = Mathf.PingPong(Time.time * moveSpeed, 1f);
        transform.position = Vector3.Lerp(startPosition, startPosition + (Vector3.forward * moveDistance), factor);
    }
}