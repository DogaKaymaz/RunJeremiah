using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject inGameScreen;
    [SerializeField] private GameObject tutorialScreen;
    [SerializeField] private GameObject escScreen;

    private bool 
        escScreenOpened, 
        tutorialScreenOpened, 
        inGameScreenOpened;

    private void Start()
    {
        tutorialScreenOpened = true;
        escScreenOpened = false;
    }

    private void Update()
    {
        
    }

    void ControlCanvas()
    {
        if (escScreenOpened)
        {
            
        }
    }
    
    void ShiftEscScreen()
    {
        if (escScreenOpened)
        {
            escScreen.SetActive(false);
        }
        else if (!escScreenOpened)
        {
            escScreen.SetActive(true);
        }
        
        escScreenOpened = !escScreenOpened;
    }

    void ShiftTutorialScreen()
    {
        if (tutorialScreenOpened)
        {
            tutorialScreen.SetActive(false);
        }
        else if (!tutorialScreenOpened)
        {
            tutorialScreen.SetActive(true);
        }

        tutorialScreenOpened = !tutorialScreenOpened;
    }
    
    
}
