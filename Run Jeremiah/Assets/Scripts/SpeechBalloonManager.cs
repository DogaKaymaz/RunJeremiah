using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using Vector3 = UnityEngine.Vector3;

public class SpeechBalloonManager : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI tutorialTextComponent;
    [SerializeField] private TextMeshProUGUI tutorialHeadTextComponent;
    
    [Header("Speech Balloon")]
    [SerializeField] private SpeechBalloonDesign startingTutorial;
    private SpeechBalloonDesign tutorial;
    
    private void Start()
    {
        tutorial = startingTutorial;
        tutorialTextComponent.SetText(tutorial.GetSpeechBalloonText());
        tutorialHeadTextComponent.SetText(tutorial.GetSpeechBalloonHeadText());
    }

    private void Update()
    {
        ManageTutorial();
    }


    void ManageTutorial()
    {
        var nextTutorial = tutorial.GetNextSpeechBalloon();

        if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            tutorial = nextTutorial[0];
            tutorialTextComponent.SetText(tutorial.GetSpeechBalloonText());
            tutorialHeadTextComponent.SetText(tutorial.GetSpeechBalloonHeadText());
        }
    }
    
}
