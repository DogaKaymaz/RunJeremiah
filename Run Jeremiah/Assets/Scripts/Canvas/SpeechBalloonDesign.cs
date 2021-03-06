using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

[CreateAssetMenu(menuName = "Speech Balloon")]
public class SpeechBalloonDesign : ScriptableObject
{
    [TextArea(5,10)] [SerializeField] private string speechBalloonText;
    [SerializeField] private SpeechBalloonDesign[] nextSpeechBalloon;
    [SerializeField] private string speechBalloonHeadText;
    
    public string GetSpeechBalloonText()
    {
        return speechBalloonText;
    }
    
    public string GetSpeechBalloonHeadText()
    {
        return speechBalloonHeadText;
    }


    public SpeechBalloonDesign[] GetNextSpeechBalloon()
    {
        return nextSpeechBalloon;
    }
    
}
