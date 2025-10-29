using UnityEngine;

public class CatTrigger : MonoBehaviour
{
    private Animator anim;
    private GameController gameController;
    private CatBumpPhysics bumpPhysics;

    private int nextKickAt = 2; // first bump at 3 cups

    void Start()
    {
        anim = GetComponent<Animator>();
        bumpPhysics = GetComponent<CatBumpPhysics>();
        gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        if (gameController == null) return;

        // Check cup count (or score)
        int cupCount = gameController.score;

        // When the tower hits the next trigger number
        if (cupCount >= nextKickAt)
        {
            // Play the bump animation once
            anim.Play("CatBump");

            // Actually bump the cups with physics
            if (bumpPhysics != null)
            {
                bumpPhysics.Invoke("BumpCups", 0.25f); // delay for animation timing
            }

            // Schedule the next bump (every 2 cups)
            nextKickAt += 2;
        }
    }
}