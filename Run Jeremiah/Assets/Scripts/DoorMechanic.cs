using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorMechanic : MonoBehaviour
{
    private Animator animatorDoor;
    private GameObject doorTextObject;
    private KeysCounter keysCounterScript;
    private LevelInformation levelInfoScript;
    [SerializeField] private float doorTextSeconds = 3f;
    [SerializeField] private TextMeshProUGUI doorText;

    private bool doorTriggered;
    
    private void Awake()
    {
        levelInfoScript = GameObject.Find("LevelInfo").GetComponent<LevelInformation>();
        keysCounterScript = GameObject.Find("Canvas").GetComponentInChildren<KeysCounter>();
        doorText = GameObject.Find("CanvasText").GetComponent<TextMeshProUGUI>();
        animatorDoor = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        GoNextLevel();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        doorTriggered = true;
        OpenDoor();
        StartCoroutine(NearDoorArea(true));
        Debug.Log("Triggered.");
    }

    private void GoNextLevel()
    {
        if (Input.GetKeyDown(KeyCode.F) && doorTriggered)
        {
            if (keysCounterScript.GetCounter() == levelInfoScript.GetKeysNumberNeeded())
            {
                Debug.Log("You Can Go To Next Level.");
            }
            else
            {
                Debug.Log("You need more keys.");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        doorTriggered = false;
        Debug.Log("Exit.");
        CloseDoor();
        StopCoroutine(NearDoorArea(false));
    }

    IEnumerator NearDoorArea(bool characterNearby)
    {
        if (characterNearby)
        {
            doorText.SetText
                ("PRESS F TO GO TO THE NEXT LEVEL \n" + 
                 "YOU NEED " + levelInfoScript.GetKeysNumberNeeded() + " KEYS.");
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
