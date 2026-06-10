using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private void Start()
    {
        // Reset time back to normal speed so buttons and physics work
        Time.timeScale = 1f;
        
        // Ensure cursor is free
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Map1");
    }
}