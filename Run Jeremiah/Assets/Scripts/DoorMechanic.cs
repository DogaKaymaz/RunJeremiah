using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorMechanic : MonoBehaviour
{
    private Animator animatorDoor;
    private GameObject doorTextObject;
    private GameObject keysCounterObject;
    [SerializeField] private float doorTextSeconds = 3f;
    [SerializeField] private TextMeshProUGUI doorText;


    private void Awake()
    {
        keysCounterObject = GameObject.Find("KeysCounter");
        doorTextObject = GameObject.Find("DoorText");
        doorText = doorTextObject.GetComponent<TextMeshProUGUI>();
        animatorDoor = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered.");
        OpenDoor();
        StartCoroutine(NearDoorArea(true));
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exit.");
        CloseDoor();
        StopCoroutine(NearDoorArea(false));
    }

    IEnumerator NearDoorArea(bool characterNearby)
    {
        if (characterNearby)
        {
            doorText.SetText("PRESS F TO GO TO THE NEXT LEVEL");
            yield return new WaitForSeconds(doorTextSeconds);
            doorText.SetText("");
        }
        else
        {
            doorText.SetText("");   
        }
    }

    private void OpenDoor()
    {
        animatorDoor.SetBool("doorOpen", true);
    }

    private void CloseDoor()
    {
        animatorDoor.SetBool("doorOpen", false);
    }
}
