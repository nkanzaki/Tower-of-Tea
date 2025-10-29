using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI resultText;    // “You Won!” or “Game Over”
    public TextMeshProUGUI scoreText;     // Shows the current score
    public TextMeshProUGUI highScoreText; // Shows the saved high score

    void Start()
    {
        // Retrieve saved info from the previous scene
        int currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        string result = PlayerPrefs.GetString("GameResult", "lose");

        // Update high score
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        // Update the texts
        if (resultText != null)
            resultText.text = (result == "win") ? "You Won!" : "Game Over";

        if (scoreText != null)
            scoreText.text = "Score: " + currentScore;

        if (highScoreText != null)
            highScoreText.text = "High Score: " + highScore;
    }

    // Called when the "Play Again" button is pressed
    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
    }

    // Optional: Called if you want to return to main menu
    public void BackToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}