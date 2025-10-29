using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Called when the Start Game button is pressed
    public void StartGame()
    {
        SceneManager.LoadScene("Main");  // Make sure your main scene is named exactly "Main"
    }
}