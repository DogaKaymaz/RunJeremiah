using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject blackBG;
    private TutorialManager tutorialManager;
    private EscManagement escManagement;
    [SerializeField] private GameObject dialogCanvas;
    [SerializeField] private AudioSource ambianceSound;

    private void Awake()
    {
        escManagement = GetComponentInChildren<EscManagement>();
        tutorialManager = GetComponentInChildren<TutorialManager>();
        ambianceSound.loop = true;
        ambianceSound.Play();
        dialogCanvas.SetActive(false);
    }

    private void Update()
    {
        ControlCanvas();
        CheckBackground();
    }

    public void ChangeDialogStatus(bool open)
    {
        if (open)
        {
            ShiftBackground(true);
            dialogCanvas.SetActive(true);
        }
        else if (!open)
        {
            ShiftBackground(false);
            dialogCanvas.SetActive(false);
        }
    }

    void ControlCanvas()
    {
        if (escManagement.escMenu.activeSelf && tutorialManager.tutorialCanvas.activeSelf)
        {
            tutorialManager.ChangeTutorialStatus();
            ShiftBackground(true);
            PauseTime(true);
        }

        if (tutorialManager.tutorialCanvas.activeSelf || escManagement.escMenu.activeSelf)
        {
            ChangeDialogStatus(false);
        }
    }

    public void TutorialClicked()
    {
        if (!tutorialManager.tutorialCanvas.activeSelf)
        {
            StartCoroutine(escManagement.ChangeESCMenuStatus());
            tutorialManager.ChangeTutorialStatus();
        }
    }

    void CheckBackground()
    {
        if (escManagement.escMenu.activeSelf || tutorialManager.tutorialCanvas.activeSelf)
        {
            ShiftBackground(true);
        }
        else
        {
            ShiftBackground(false);
        }
    }

    void ShiftBackground(bool activate)
    {
        if (activate)
        {
            blackBG.SetActive(true);
            ambianceSound.Pause();
        }
        else if (!activate)
        {
            ambianceSound.UnPause();
            blackBG.SetActive(false);
        }
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
