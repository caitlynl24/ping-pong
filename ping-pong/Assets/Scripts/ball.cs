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
        //Probably put a coditional statement here so it goes toward each player based on who won last or a randomizer for which way the ball will go
        direction = Vector2.right;
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