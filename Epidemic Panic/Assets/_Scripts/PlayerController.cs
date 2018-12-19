using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public int lives;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    public bool lookDirection = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        if(moveInput.x > 0 && lookDirection)
        {
            Flip();
        }
        if (moveInput.x < 0 && !lookDirection)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        
    }

    void Flip()
    {
        lookDirection = !lookDirection;
        transform.Rotate(Vector3.up * 180);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "WhiteCell")
        {
            lives--;
            Destroy(gameObject);
        }
    }
}
