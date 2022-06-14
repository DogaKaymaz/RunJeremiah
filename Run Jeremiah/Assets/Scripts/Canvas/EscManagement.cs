using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscManagement : MonoBehaviour
{ 
    [SerializeField] public GameObject escMenu;
    [SerializeField] private Animator animatorBalloons;
    private bool showEscBool;
    private SoundsList soundsList;
    private AudioSource audioSource;
   
    private void Start()
    {
        soundsList = GameObject.Find("Sounds").GetComponent<SoundsList>();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = soundsList.GetMenuSound();
        audioSource.Play();
        audioSource.Pause();
        audioSource.loop = true;
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
        animatorBalloons.SetFloat("balloons", 0f); 
        showEscBool = !showEscBool; 
        escMenu.SetActive(showEscBool); 
        PauseTime(showEscBool);
        PlayMusic(showEscBool);
        yield return new WaitForSecondsRealtime(animatorBalloons.GetCurrentAnimatorStateInfo(0).length + 
                                        animatorBalloons.GetCurrentAnimatorStateInfo(0).normalizedTime); 
        animatorBalloons.SetFloat("balloons", 0.5f);
        }
    

    void PlayMusic(bool play)
    {
        if (play)
        {
            audioSource.UnPause();
        }
        else if (!play)
        {
            audioSource.Pause();
        }
    }
    
    void PauseTime(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0f;
            AudioSource.PlayClipAtPoint(soundsList.GetOpenTabSound(), Camera.main.transform.position);
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
