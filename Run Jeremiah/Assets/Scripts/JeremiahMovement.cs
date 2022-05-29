using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [Header("Ladder Movement")] 
    private bool isLadder;
    private bool isClimbing;
    private float vertical;
    [SerializeField] private float climbingSpeed = 8f;

    [Header("Audio")] [SerializeField] private AudioClip jumpSound;
    
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
        IfClimbing();
    }

    private void FixedUpdate()
    {
        Climb();
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
        if ( jumpButtonTaken && Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            jumpButtonTaken = false;
            rb.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
            AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position);
        }
        else
        {
            jumpButtonTaken = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }

    private void IfClimbing()
    {
        vertical = Input.GetAxis("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0)
        {
            isClimbing = true;
        }
    }

    void Climb()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * climbingSpeed);
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    private void TakeJumpButton()
    {
        if((Input.GetKeyDown(KeyCode.W) || 
           Input.GetKeyDown(KeyCode.UpArrow)) && 
           !isLadder )
        {
            jumpButtonTaken = true;
        }
        else
        {
            jumpButtonTaken = false;
        }
    }

}
