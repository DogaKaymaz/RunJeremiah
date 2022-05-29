using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationChange : MonoBehaviour
{
    public bool enteredRoom;
    public void ChangeLocation(Transform location)
    { 
        transform.position = location.position;
        enteredRoom = !enteredRoom;
    }

}
