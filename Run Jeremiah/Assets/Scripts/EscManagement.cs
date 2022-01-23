using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscManagement : MonoBehaviour
{ 
    [SerializeField] private GameObject escMenu;
    [SerializeField] private Animator animatorBalloons;
    private bool showEscBool;
    private void Awake()
    {
        showEscBool = false;
        escMenu.SetActive(showEscBool);
    }

    private void Update()
    {
        StartCoroutine(OpenESCMenu());
    }

    private IEnumerator OpenESCMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            animatorBalloons.SetFloat("balloons", 1f);
            showEscBool = !showEscBool;
            escMenu.SetActive(showEscBool);
            // PauseOrResume(showEscBool);
            yield return new WaitForSeconds(animatorBalloons.GetCurrentAnimatorStateInfo(0).length +
                                       animatorBalloons.GetCurrentAnimatorStateInfo(0).normalizedTime);
            animatorBalloons.SetFloat("balloons", 0.5f);
        }
    }

    public void DisableCanvas()
    {
        escMenu.SetActive(!showEscBool);
    }
    
    
    // void PauseOrResume(bool pause)
    // {
    //     if (pause)
    //     {
    //         Time.timeScale = 0f;
    //     }
    //     else
    //     {
    //         Time.timeScale = 1f;
    //     }
    // }
}
