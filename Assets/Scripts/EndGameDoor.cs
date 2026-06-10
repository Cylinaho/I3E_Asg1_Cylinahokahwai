using UnityEngine;

public class EndGameDoor : MonoBehaviour
{
    public string sceneToLoad = "MainMenu"; // Name of the scene to load when the player enters the door
    private void OnTriggerEnter(Collider other)
    {
        Player playerScript = other.gameObject.GetComponent<Player>();

        if (playerScript != null)
        {
            // Load the specified scene when the player enters the door
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
        }
    }
}

