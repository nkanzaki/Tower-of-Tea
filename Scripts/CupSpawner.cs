using UnityEngine;

public class CupSpawner : MonoBehaviour
{
    public GameObject cupPrefab;
    public float spawnY = 4.5f;     // where the cup appears
    public float horizontalClamp = 8f;  // how far left/right the cup can go

    // cooldown variables to prevent instant re-clicks
    private float dropCooldown = 0.2f;
    private float nextDropTime = 0f;


    private GameObject currentCup;
    private Camera cam;


    void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {

        // spawn new cup if none exists
        if (currentCup == null)
        {
            currentCup = Instantiate(cupPrefab, new Vector2(0, spawnY), Quaternion.identity);
            var rb = currentCup.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            currentCup.GetComponent<Collider2D>().enabled = false; // disable while hovering
        }


        // move cup with mouse
        Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        float clampedX = Mathf.Clamp(mouse.x, -horizontalClamp, horizontalClamp);
        currentCup.transform.position = new Vector2(clampedX, spawnY);

        // drop on left-click or spacebar
        if (Time.time >= nextDropTime &&
            (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            var rb = currentCup.GetComponent<Rigidbody2D>();
            var col = currentCup.GetComponent<Collider2D>();

            // enable collider first, then drop
            col.enabled = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.angularVelocity = Random.Range(-20f, 20f);

        
        
            FindObjectOfType<GameController>().AddScore(1);

            currentCup = null;
            nextDropTime = Time.time + dropCooldown;
            
        }

    }
}
