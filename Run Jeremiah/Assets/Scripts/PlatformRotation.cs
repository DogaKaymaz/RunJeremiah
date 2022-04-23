using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using DG.Tweening;

public class PlatformRotation : MonoBehaviour
{
    [SerializeField] private Vector3 moveDistance = new Vector3(0f,10f,0f);
    [SerializeField] private float loopDuration = 2f; 
 
    private Vector3 startingPosition;
    
   [SerializeField] private List<GameObject> wayPointsObjects;
   private List<Vector3> wayPointsList;
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
        foreach ( var wayPoint in wayPointsObjects)
        {
            wayPointsList.Add(wayPoint.transform.position);
        }

        wayPoints = wayPointsList.ToArray();
    }

    void RotatePlatform()
    {
        if (transform.position == startingPosition)
            transform.DOPath(wayPoints, loopDuration, PathType.CatmullRom);
    }

    // void TurnBack()
    // {
    //     chosenTransform.DORotateQuaternion(startingPosition, loopDuration);
    //      chosenTransform.DOMove(startingPosition, loopDuration);
    // }
    //
}
