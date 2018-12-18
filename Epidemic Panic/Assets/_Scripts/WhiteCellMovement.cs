using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCellMovement : MonoBehaviour
{
    public Transform player; //the enemy's target
    public float moveSpeed = 1; //move speed
    public float rotationSpeed = 5; //speed of turning

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
}
