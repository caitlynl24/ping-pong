using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    public float speed;
    public Vector2 direction;
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
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("left_paddle") || collision.gameObject.CompareTag("right_paddle"))
        {
            //Reverse horizontal direction
            direction.x = -direction.x;
        }

        else if(collision.gameObject.CompareTag("wall"))
        {
            //Reverse vertical direction
            direction.y = -direction.y;
        }

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
}