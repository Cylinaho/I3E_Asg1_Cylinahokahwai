using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public Vector3 rotateAmount = new Vector3(0, 90, 0); // Amount to rotate when opening the door

    bool isOpen = false; // Whether the door is open or closed

    public void Interact()
    {
        if (!isOpen)
        {
            transform.Rotate(rotateAmount); // Rotate the door to open it
            isOpen = true;
        }
        else
        {
            transform.Rotate(-rotateAmount); // Rotate back to close the door
            isOpen = false;
        }
    }
}
