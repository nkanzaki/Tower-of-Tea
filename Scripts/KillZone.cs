using UnityEngine;

public class KillZone : MonoBehaviour
{
    private bool gameStarted = false;

    private void Start()
    {
        // Wait a short moment before detecting
        Invoke(nameof(EnableDetection), 1f);
    }

    void EnableDetection() => gameStarted = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameStarted) return;

        if (other.CompareTag("Cup"))
        {
            FindObjectOfType<GameController>().GameOver();
        }
    }
}