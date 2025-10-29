using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public int score = 0;
    private bool isGameOver = false;

    void Start()
    {
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);

        UpdateScoreText();

        AudioManager.instance.PlayAmbient();
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        score += amount;
        UpdateScoreText();

        // WIN CONDITION — 6 cups
        if (score >= 6)
        {
            PlayerPrefs.SetInt("CurrentScore", score);
            PlayerPrefs.SetString("GameResult", "win");
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameOver");
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Cups: " + score;
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        PlayerPrefs.SetInt("CurrentScore", score);
        PlayerPrefs.SetString("GameResult", "lose");
        PlayerPrefs.Save();

        SceneManager.LoadScene("GameOver");
    }

    // Manual restart for testing
    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}