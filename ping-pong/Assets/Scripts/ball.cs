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
        //Probably put a coditional statement here so it goes toward each player based on who won last
        direction = Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("left_paddle"))
        {
            direction.x = -direction.x;
        }

        else if(collision.gameObject.CompareTag("right_paddle"))
        {
            direction.x = -direction.x;
        }
    }
}