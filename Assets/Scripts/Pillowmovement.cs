using UnityEngine;

public class MovingPillow : MonoBehaviour
{
    public float moveDistance = 5f; // Distance the pillow will move back and forth 
    public float moveSpeed = 2f; // Speed of the movement (adjust in Inspector for faster/slower movement)          

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
}