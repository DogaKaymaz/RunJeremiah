using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PortalMechanic : MonoBehaviour
{
    private LocationChange locationChange;
    private CameraControl cameraControl;
    private bool triggered;
    [SerializeField] private TextMeshProUGUI portalText;
    [SerializeField] private Transform locationToReach;
    [TextArea(5,10)] [SerializeField] private string text;
    [SerializeField] private AudioClip portalSound; 

    private void Awake()
    {
        cameraControl = FindObjectOfType<CameraControl>();
    }

    private void Update()
    {
        if (triggered)
        {
            RunPortal();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out LocationChange localLocationChange))
        {
            locationChange = localLocationChange;
            triggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        triggered = false;
        ClosePortal();
    }

    private void RunPortal()
    {
        portalText.SetText(text);
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeLocation();
        }
    }
    private void ChangeLocation()
    {
        locationChange.ChangeLocation(locationToReach);
        ChangeCam(locationChange.enteredRoom);
    }

    private void ClosePortal()
    {
        portalText.SetText(String.Empty);
    }

    void ChangeCam(bool charecterInRoom)
    {
        if (charecterInRoom)
        {
            cameraControl.RunRoomCam();
            AudioSource.PlayClipAtPoint(portalSound, cameraControl.roomCam.transform.position);
        }
        else if (!charecterInRoom)
        {
            cameraControl.RunLevelCam();
            AudioSource.PlayClipAtPoint(portalSound, cameraControl.levelCam.transform.position);
        }
    }
}
