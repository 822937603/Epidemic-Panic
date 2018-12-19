using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectBulletController : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    public GameObject StageManagerGameObject;
    public StageManager StageManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        StageManagerGameObject = GameObject.Find("StageManager");
        StageManagerScript = StageManagerGameObject.GetComponent<StageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BrainCell")
        {
            StageManagerScript.organCellRemaining--;
        }
        if (collision.gameObject.tag == "WhiteCell")
        {
            StageManagerScript.whiteCellsKilled++;
        }
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
