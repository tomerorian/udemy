using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    float moveDirection = 1;

    Rigidbody2D myRigidBody;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        myRigidBody.velocity = new Vector2(moveSpeed * moveDirection, myRigidBody.velocity.y);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        moveDirection *= -1;
        transform.localScale = new Vector2(moveDirection, 1f);
    }
}
