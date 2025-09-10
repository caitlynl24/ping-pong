using UnityEngine;

public class right_paddle_controller : MonoBehaviour
{
    Rigidbody2D pad;
    Vector2 initial;
    public float displacement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pad = GetComponent<Rigidbody2D>();
        initial = pad.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKey(KeyCode.P)))
        {
            if(initial.y <= 3.6)
            {
                initial.y = initial.y + displacement;
            }
        }

        else if((Input.GetKey(KeyCode.L)))
        {
            if(initial.y >= -3.6)
            {
                initial.y = initial.y - displacement;
            }
        }

        pad.MovePosition(initial);
    }
}