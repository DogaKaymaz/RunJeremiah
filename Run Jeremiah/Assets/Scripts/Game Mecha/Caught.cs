using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Caught : MonoBehaviour
{
    private bool triggered;
    private GameManagement gameManagement;
    private CanvasManager canvasManager;
    private SoundsList soundsList;
    private bool once = true;

    private void Start()
    {
        soundsList = GameObject.Find("Sounds").GetComponent<SoundsList>();
        gameManagement = GameObject.Find(("GameManager")).GetComponent<GameManagement>();
        canvasManager = GameObject.Find("Canvas").GetComponent<CanvasManager>();
    }
    
    IEnumerator EndScene()
    {
        AudioSource.PlayClipAtPoint(soundsList.GetFailedSound(), Camera.main.transform.position);
        canvasManager.ChangeDialogStatus(true);
        yield return new WaitForSeconds(10f);
        gameManagement.PlaySameLevel(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out JeremiahMovement jeremiahMovement) && once)
        {
            once = false;
            StartCoroutine(EndScene());
        }
    }
    
    
}
