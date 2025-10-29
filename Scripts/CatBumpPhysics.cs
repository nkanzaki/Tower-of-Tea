using UnityEngine;

public class CatBumpPhysics : MonoBehaviour
{
    [Header("Cat Movement")]
    public float leftX = 3.1f;
    public float rightX = 3.4f;
    public float moveSpeed = 2f;

    [Header("Meow Settings")]
    public float meowCooldown = 1.5f; // delay between meows

    private float lastMeowTime;
    private bool movingLeft = true;

    void Update()
    {
        float targetX = movingLeft ? leftX : rightX;
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetX, transform.position.y), step);

        // When cat reaches a side
        if (Mathf.Abs(transform.position.x - targetX) < 0.01f)
        {
            if (movingLeft)
            {
                // Meow each time it bumps
                if (Time.time - lastMeowTime > meowCooldown)
                {
                    AudioManager.instance.PlayCatSound();
                    Debug.Log("😼 Meow.");
                    lastMeowTime = Time.time;
                }
            }

            movingLeft = !movingLeft;
        }
    }
}