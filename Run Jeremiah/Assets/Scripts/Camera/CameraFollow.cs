using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   [SerializeField] private Transform followTransform;
   [SerializeField] private Transform upperWallTransform;

   private void FixedUpdate()
   {
       if (followTransform.position.y <= upperWallTransform.position.y)
       {
           this.transform.position =
               new Vector3(transform.position.x, followTransform.position.y, transform.position.z);
       }
   }
}
