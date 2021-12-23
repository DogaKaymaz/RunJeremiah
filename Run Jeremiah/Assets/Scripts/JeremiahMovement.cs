using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JeremiahMovement : MonoBehaviour
{
    private Camera gameCamera;
    private float
        minX,
        maxX,
        minY,
        maxY;

    private float
        changePosX,
        changePosY;

    private Animator animatorJeremiah;
    
    [Header("Player Movement")]
    [SerializeField] private float paddingX = 1f;
    [SerializeField] private float paddingY = 2f;
    [SerializeField] private float moveSpeed;

    private void Awake()
    {
        gameCamera = Camera.main;
        SetUpTheBoundaries();
        animatorJeremiah = GetComponent<Animator>();
    }
    
    void Update()
    {
        Move();
    }
    
    void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        if (deltaX != 0)
        {
            animatorJeremiah.SetFloat("atAction", 1f, 0.1f, Time.deltaTime);
            changePosX = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        }
        else
        {
            animatorJeremiah.SetFloat("atAction", 0f, 0.1f, Time.deltaTime);
        }

        if (deltaY != 0)
        {
            changePosY = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);
        }
        

        transform.position = new Vector2(changePosX, changePosY);
    }
    
    void SetUpTheBoundaries()
    {
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + paddingX;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - paddingX;

        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + paddingY;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - paddingY;
    }
}
