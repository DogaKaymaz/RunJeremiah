using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject levelCam, roomCam;
    private void Awake()
    {
        levelCam = transform.GetChild(0).gameObject;
        roomCam = transform.GetChild(1).gameObject;
        RunLevelCam();
    }

    public void RunLevelCam()
    {
        levelCam.gameObject.SetActive(true);
        roomCam.gameObject.SetActive(false);
    }

    public void RunRoomCam()
    {
        roomCam.gameObject.SetActive(true);
        levelCam.gameObject.SetActive(false);
    }
    
}
