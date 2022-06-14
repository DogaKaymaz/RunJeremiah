using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using DG.Tweening;

public class PlatformRotation : MonoBehaviour
{
    [SerializeField] private float loopDuration = 2f; 
 
    private Vector3 startingPosition;
    
   [SerializeField] private List<Transform> wayPointsTransforms;
   private Vector3[] wayPoints;

    private void Awake()
    {
        startingPosition = transform.position;
        GetWayPoints();
    }

    private void Update()
    {
        RotatePlatform();
    }

    void GetWayPoints()
    {
        wayPoints = wayPointsTransforms.Select(wayPoint => wayPoint.transform.position).ToArray();
    }

    void RotatePlatform()
    {
        if (transform.position == startingPosition)
            transform.DOPath(wayPoints, loopDuration, PathType.CatmullRom);
    }

   
}
