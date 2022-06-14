using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private SoundsList soundsList;
    private AudioSource audioSource;
    private void Awake()
    {
        soundsList = GameObject.Find("Sounds").GetComponent<SoundsList>();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = soundsList.GetMenuSound();
        audioSource.loop = true;
        audioSource.Play();
    }
}
