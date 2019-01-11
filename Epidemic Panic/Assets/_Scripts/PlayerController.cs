using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float speedInput;
    public float turnInput;

    public int lives;

    public GameObject shot;
    public float shotForce;
    public Transform shotPosition;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    public bool lookDirection = true;

    private GameOverUI gameOverUIScript;

    // Start is called before the first frame update
    void Start()
    {
        gameOverUIScript = GameObject.FindGameObjectWithTag("StageManager").GetComponent<GameOverUI>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        speedInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Fire1"))
        {
            GameObject newShot = Instantiate(shot, shotPosition.position, shotPosition.rotation);
            newShot.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * shotForce);
            Destroy (newShot, 5.0f); //To destroy shot once it leaves the camera area
        }
        /*Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        if(moveInput.x > 0 && lookDirection)
        {
            Flip();
        }
        if (moveInput.x < 0 && !lookDirection)
        {
            Flip();
        }*/
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector2.up * speedInput * speed);
        rb.AddTorque(-turnInput * turnSpeed);
        //rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        
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
            gameOverUIScript.GameOver();
            Destroy(gameObject);
        }
    }
}
