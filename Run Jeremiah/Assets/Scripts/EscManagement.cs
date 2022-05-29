using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscManagement : MonoBehaviour
{ 
    [SerializeField] public GameObject escMenu;
    [SerializeField] private Animator animatorBalloons;
    private bool showEscBool;
    [SerializeField] private AudioClip tabSound;
   
    private void Start()
    {
        showEscBool = false;
        escMenu.SetActive(showEscBool);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(ChangeESCMenuStatus());
        }
    }

    public IEnumerator ChangeESCMenuStatus()
    {
        animatorBalloons.SetFloat("balloons", 1f); 
        showEscBool = !showEscBool; 
        escMenu.SetActive(showEscBool); 
        PauseTime(showEscBool); 
        yield return new WaitForSeconds(animatorBalloons.GetCurrentAnimatorStateInfo(0).length +
                                                                animatorBalloons.GetCurrentAnimatorStateInfo(0).normalizedTime); 
        animatorBalloons.SetFloat("balloons", 0.5f);
        }
    
    
    void PauseTime(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0f;
            AudioSource.PlayClipAtPoint(tabSound, Camera.main.transform.position);
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
