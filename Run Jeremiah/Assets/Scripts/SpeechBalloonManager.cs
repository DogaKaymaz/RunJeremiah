using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class SpeechBalloonManager : MonoBehaviour
{
    // [Header("Own Character")]
    // [SerializeField] private Animator animatorOwn;
    // private bool changeEmotionBool;
    // [SerializeField] private GameObject ownObject;
    
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI tutorialTextComponent;
    
    [Header("Background")]
    [SerializeField] private GameObject tutorialBG;
    // private Vector3 fixedTBGposition;
    
    [Header("Speech Balloon")]
    [SerializeField] private SpeechBalloonDesign startingTutorial;
    // [SerializeField] private GameObject characterExitObject;
    // [SerializeField] private GameObject characterEnterObject;
    [SerializeField] private Animator animatorBalloon;
    private SpeechBalloonDesign tutorial;
    
    [Header("Tutorial Canvas")]
    [SerializeField] private GameObject tutorialCanvas;
    private bool showCanvasBool;
  
    // [Header("Jeremiah")]
    // [SerializeField] private JeremiahMovement jeremiahMovementScript;
    
    private void Awake()
    {
        // ownObject.transform.position = characterExitObject.transform.position;
        showCanvasBool = true;
        //Set Active tutorial objects.
        tutorialBG.SetActive(showCanvasBool);
        // ownObject.SetActive(showCanvasBool);
        tutorialCanvas.gameObject.SetActive(showCanvasBool);
        tutorialCanvas.gameObject.SetActive(showCanvasBool);
    }

    private void Start()
    {
        tutorial = startingTutorial;
        tutorialTextComponent.SetText(tutorial.GetSpeechBalloonText());
        animatorBalloon.SetBool("show", showCanvasBool);
        // changeEmotionBool = false;
        // ownObject.transform.DOMove(characterEnterObject.transform.position,1);
        PauseOrResume(showCanvasBool);
    }

    private void Update()
    {
        ManageTutorial();
        ShowTutorial();
    }

    private void ShowTutorial()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TutorialPage();
        }
    }


    public void TutorialPage()
    {
        showCanvasBool = !showCanvasBool;
        Debug.Log(showCanvasBool);
        // ShowCharacter(showCanvasBool);
        animatorBalloon.SetBool("show", showCanvasBool);
        tutorialBG.SetActive(showCanvasBool);
        PauseOrResume(showCanvasBool);
    }


  
    
    void ManageTutorial()
    {
        var nextTutorial = tutorial.GetNextSpeechBalloon();

        if ((Input.GetKeyUp(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && showCanvasBool)
        {
            tutorial = nextTutorial[0];
            tutorialTextComponent.SetText(tutorial.GetSpeechBalloonText());
            // changeEmotionBool = !changeEmotionBool;
            // animatorOwn.SetBool("ChangeEmotion", changeEmotionBool);
        }
    }
    
    void PauseOrResume(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    
    
    // private void ShowCharacter(bool show)
    // {
    //     
    //     if(show)
    //     {
    //         ownObject.transform.DOMove(characterEnterObject.transform.position,2f);
    //         tutorialBG.transform.DOMove(fixedTBGposition, 2f);
    //     }
    //     else
    //     {
    //         ownObject.transform.DOMove(characterExitObject.transform.position,2f);
    //         tutorialBG.transform.DOMove(fixedTBGposition + new Vector3(50f,0,0), 2f);
    //     }
    // }
}
