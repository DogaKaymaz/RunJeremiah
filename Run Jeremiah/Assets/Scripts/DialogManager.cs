using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [Header("Dialog")]
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private TextMeshProUGUI charName;
    [SerializeField] private Image charPortre;
    
    [Header("Dialog")]
    [SerializeField] private DialogDesign startingDialog;
    private DialogDesign dialog;
    
    private void Start()
    {
        dialog = startingDialog;
        dialogText.SetText(dialog.GetDialogText());
        charName.SetText(dialog.GetCharacterName());
        charPortre.sprite = dialog.GetCharacterPortre();
    }

    private void Update()
    {
        ManageDialog();
    }


    void ManageDialog()
    {
        var nextDialog = dialog.GetNextDialog();

        if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            dialog = nextDialog[0];
            dialogText.SetText(dialog.GetDialogText());
            charName.SetText(dialog.GetCharacterName());
            charPortre.sprite = dialog.GetCharacterPortre();
        }
    }
}
