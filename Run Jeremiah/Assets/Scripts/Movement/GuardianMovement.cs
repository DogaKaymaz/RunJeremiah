using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GuardianMovement : MonoBehaviour
{
    [SerializeField] private Vector3 moveDistance = new Vector3(5f,0f,0f);
    [SerializeField] private float loopDuration = 2f; 
    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        if (transform.position == startingPosition)
        {
            transform.rotation = startingPosition.x > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
            transform.DOMove(startingPosition + moveDistance, loopDuration).OnComplete(() => TurnBack());
        }
    }

    void TurnBack()
    {
        transform.DOMove(startingPosition, loopDuration);
        transform.rotation = startingPosition.x < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }
}
