using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog")]
public class DialogDesign : ScriptableObject
{
    [SerializeField] private CharacterDesign characterDesign;
    [TextArea(5,10)] [SerializeField] private string dialogText;
    [SerializeField] private DialogDesign[] dialog;
    [SerializeField] private bool itemToken;
    
    public string GetCharacterName()
    {
        return characterDesign.characterName;
    }
    
    public string GetDialogText()
    {
        return dialogText;
    }

    public Sprite GetCharacterPortre()
    {
        return characterDesign.characterPortre;
    }
    
    public DialogDesign[] GetNextDialog()
    {
        return dialog;
    }

    // public bool ItemToken()
    // {
    //     return itemToken;
    // }

  
    
}
