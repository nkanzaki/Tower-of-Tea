using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        int currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        string result = PlayerPrefs.GetString("GameResult", "lose");

        // Update result message
        if (resultText != null)
            resultText.text = result == "win" ? "🎉 You Win!" : "💔 Game Over";

        // Display current score
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore;

        // Update & display high score
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        if (highScoreText != null)
            highScoreText.text = "High Score: " + highScore;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("MainGame");
    }
}