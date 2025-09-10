using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    public float speed = 5f;
    public Vector2 direction;

    private float timeElapsed = 0f;
    private float speedIncreaseInterval = 15f;
    //how much to increase speed by each time
    public float speedIncrement = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Randomize initial direction
        //Random.Range(0, 2) gives either 0 or 1
        float xDir = Random.Range(0, 2) == 0 ? -1f : 1f;
        float yDir = Random.Range(0, 2) == 0 ? -1f : 1f;

        direction = new Vector2(xDir, yDir);
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = direction * speed;

        //Time tracking for speed increase
        timeElapsed += Time.deltaTime;

        if(timeElapsed >= speedIncreaseInterval)
        {
            speed += speedIncrement;
            //Reset timer to allow next speed increase
            timeElapsed = 0f;
            Debug.Log("Ball speed increased to: " + speed);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("left_paddle") || collision.gameObject.CompareTag("right_paddle"))
        {
            //Reverse horizontal direction
            direction.x = -direction.x;

             //Calculate hit factor
            float paddleY = collision.transform.position.y;
            float ballY = transform.position.y;

            float paddleHeight = collision.bounds.size.y;

            //Get difference relative to paddle height, normalized between -1 and 1
            float hitFactor = (ballY - paddleY) / paddleHeight;

            //Adjust vertical direction based on hit point
            direction.y = hitFactor;

            //Normalize to keep speed consistent
            direction = direction.normalized;
        }

        else if(collision.gameObject.CompareTag("wall"))
        {
            //Reverse vertical direction
            direction.y = -direction.y;
        }
    }
}