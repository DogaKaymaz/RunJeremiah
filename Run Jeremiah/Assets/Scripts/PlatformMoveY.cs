using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlatformMoveY : MonoBehaviour
{
    [SerializeField] private Vector3 moveDistance = new Vector3(0f,10f,0f);
    [SerializeField] private float movingTime = 2f;

    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position == startingPosition)
        {
            transform.DOMove(transform.position + moveDistance, movingTime, false).SetLoops(-1, LoopType.Yoyo);
        }
        else if (transform.position == startingPosition + moveDistance)
        {
            transform.DOMove(transform.position - moveDistance, movingTime, false).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
