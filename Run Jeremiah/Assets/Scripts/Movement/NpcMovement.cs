using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    private Animator animatorNpc;
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI npcText;
    [TextArea(5,10)] [SerializeField] private string text;
    [SerializeField] private CanvasManager canvasManager;
    private bool triggered, openDialog;

    private void Start()
    {
        animatorNpc = GetComponent<Animator>();
    }

    private void Update()
    {
        Turn();

        if (triggered && Input.GetKeyDown(KeyCode.F))
        {
            openDialog = !openDialog;
            canvasManager.ChangeDialogStatus(openDialog);
            npcText.SetText(String.Empty);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out JeremiahMovement jeremiahMovement))
        {
            npcText.SetText(text);
            triggered = true;
        }
    }

   
    private void OnTriggerExit2D(Collider2D other)
    {
        triggered = false;
        npcText.SetText(String.Empty);
        openDialog = false;
        canvasManager.ChangeDialogStatus(openDialog);
    }

    void Turn()
    {
        var distanceChar = transform.position.x - player.transform.position.x;
        transform.rotation = distanceChar > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
    }
}
