using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JeremiahMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private float movementSpeed = 1f;

    private bool jumpButtonTaken;
    Rigidbody2D rb;

    private Animator animatorJeremiah;

    private void Awake()
    {
        animatorJeremiah = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        TakeJumpButton();
        Jump();
    }

    private void Move()
    {
        var movement = Input.GetAxis("Horizontal");

        if (!Mathf.Approximately(0, movement))
        {
            transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }
        
        if (movement != 0f)
        {
            animatorJeremiah.SetFloat("atAction", 1f, 0.1f, Time.deltaTime);
        }
        else
        {
            animatorJeremiah.SetFloat("atAction", 0f, 0.1f, Time.deltaTime);
   
        }
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
    }

    private void Jump()
    {
        if ( jumpButtonTaken && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            jumpButtonTaken = false;
            rb.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
        }
        else
        {
            jumpButtonTaken = false;
        }
    }

    private void TakeJumpButton()
    {
        if(Input.GetKeyDown(KeyCode.Space) || 
           Input.GetKeyDown(KeyCode.W) || 
           Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumpButtonTaken = true;
        }
        else
        {
            jumpButtonTaken = false;
        }
    }
}
