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
}