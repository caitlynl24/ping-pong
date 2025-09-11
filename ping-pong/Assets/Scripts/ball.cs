using UnityEngine;

public class ball : MonoBehaviour
{
    [Header("Gameplay References")]
    //Reference to the score manager, assign in Inspector
    public ScoreManager scoreManager;

    [Header("Ball Settings")]
    public float speed = 5f;
    //Amount to increase speed
    public float speedIncrement = 1f;
    //Time in seconds to increase speed
    public float speedIncreaseInterval = 15f;

    private Rigidbody2D rb;
    private Vector2 direction;
    private float timeElapsed = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Set initial direction randomly
        float xDir = Random.Range(0, 2) == 0 ? -1f : 1f;
        float yDir = Random.Range(0, 2) == 0 ? -1f : 1f;
        direction = new Vector2(xDir, yDir).normalized;
    }

    void Update()
    {
        //Move the ball based on current direction and speed
        rb.linearVelocity = direction * speed;

        //Track time to increase speed over intervals
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= speedIncreaseInterval)
        {
            speed += speedIncrement;
            //Reset timer
            timeElapsed = 0f;
            Debug.Log("Ball speed increased to: " + speed);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;

        if(tag == "left_paddle" || tag == "right_paddle")
        {
            //Reverse horizontal direction
            direction.x = -direction.x;

             //Calculate vertical direction based on collision point
            float paddleY = collision.transform.position.y;
            float ballY = transform.position.y;
            float paddleHeight = collision.bounds.size.y;

            //Range [-1, 1]
            float hitFactor = (ballY - paddleY) / paddleHeight;
            direction.y = hitFactor;

            //Normalize to maintain consistent speed
            direction = direction.normalized;
        }
        else if(tag == "wall")
        {
            //Bounce off top or bottom wall
            direction.y = -direction.y;
        }
        else if(tag == "leftWall")
        {
            scoreManager.RightPlayerScores();
        }
        else if(tag == "rightWall")
        {
            scoreManager.LeftPlayerScores();
        }
    }

    public void ResetBall(int startingDirection)
    {
        //Reset ball to center
        transform.position = Vector2.zero;

        //Random slight vertical component
        float yDir = Random.Range(0, 2) == 0 ? -1f : 1f;
        direction = new Vector2(startingDirection, yDir).normalized;

        //Reset speed and timer
        speed = 5f;
        timeElapsed = 0f;
    }
}