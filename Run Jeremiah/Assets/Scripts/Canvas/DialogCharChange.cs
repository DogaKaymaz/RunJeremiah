using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogCharChange : MonoBehaviour
{
    [SerializeField] private DialogManager dialogManager;

    public void GuardianDialog()
    {
        dialogManager.GuardianDialog();
        Debug.Log("Guardian Dialog Activated.");
    }
    
    public void NpcDialog()
    {
        dialogManager.NpcDialog();
        Debug.Log("Npc Dialog Activated.");
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out JeremiahMovement jeremiahMovement))
        {
            GuardianDialog();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        NpcDialog();
    }
}
