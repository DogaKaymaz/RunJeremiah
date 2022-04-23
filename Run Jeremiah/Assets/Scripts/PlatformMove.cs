using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private Vector3 moveDistance = new Vector3(0f,10f,0f);
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
        if(transform.position == startingPosition)
            transform.DOMove(startingPosition + moveDistance, loopDuration).OnComplete(()=>TurnBack());
    }

    void TurnBack()
    {
        transform.DOMove(startingPosition, loopDuration);
    }
    
}
