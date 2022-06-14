using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsList : MonoBehaviour
{
    [Header("Character Sounds")] [SerializeField] private AudioClip
        jump,
        portal,
        collectKey,
        failed;

    [Header("Menu Sounds")] [SerializeField] private AudioClip
        openTab,
        transition;

    [Header("Music")] [SerializeField] private AudioClip
        ambiance,
        menu;
    
    public AudioClip GetJumpSound()
    {
        return jump; 
    }

    public AudioClip GetPortalSound()
    {
        return portal;
    }
    
    public AudioClip GetCollectKeySound()
    {
        return collectKey;
    }

    public AudioClip GetOpenTabSound()
    {
        return openTab;
    }
    
    public AudioClip GetTransitionSound()
    {
        return transition;
    }

    public AudioClip GetMenuSound()
    {
        return menu;
    }
    
    public AudioClip GetAmbianceSound()
    {
        return ambiance;
    }
    
    public AudioClip GetFailedSound()
    {
        return failed;
    }
}
