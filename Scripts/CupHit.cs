using UnityEngine;

public class CupHit : MonoBehaviour
{
    [Header("Clink Settings")]
    public float minImpact = 0.05f;
    public float cooldown = 0.1f;
    private float lastClinkTime;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Only react to table or another cup
        if (!collision.collider.CompareTag("table") && !collision.collider.CompareTag("Cup"))
            return;

        // Prevent weak hits or spam
        if (collision.relativeVelocity.magnitude < minImpact) return;
        if (Time.time - lastClinkTime < cooldown) return;

        // Play clink sound directly through AudioManager
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayClink();
            Debug.Log($"🔊 CLINK between {name} & {collision.collider.name} | velocity {collision.relativeVelocity.magnitude:F2}");
        }
        else
        {
            Debug.LogWarning("🛑 AudioManager.instance missing!");
        }

        lastClinkTime = Time.time;
    }
}