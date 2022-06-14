using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [Header("Tutorial Canvas")]
    [SerializeField] public GameObject tutorialCanvas;
    private SoundsList soundsList;
    [SerializeField] private float duration = 2f;
    private bool tutorialKeyToken;
    private void Awake()
    {
        soundsList = GameObject.Find("Sounds").GetComponent<SoundsList>();
        tutorialCanvas.gameObject.SetActive(true);
        PauseTime(tutorialCanvas.activeSelf);
        tutorialKeyToken = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown((KeyCode.T)) & !tutorialKeyToken)
        {
            tutorialKeyToken = true;
            ChangeTutorialStatus();
        }
    }

    public void ChangeTutorialStatus()
    {
        if (!tutorialCanvas.activeSelf)
        {
            tutorialCanvas.SetActive(true);
            PauseTime(true);
            AudioSource.PlayClipAtPoint(soundsList.GetOpenTabSound(), Camera.main.transform.position);
        }
        else if (tutorialCanvas.activeSelf)
        {
            tutorialCanvas.SetActive(false);
            PauseTime(false);
        }
        tutorialKeyToken = false;
    }

    void PauseTime(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0f;
        }
        else if (!pause)
        {
            Time.timeScale = 1f;
        }
    }

}
