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
    [SerializeField] private DialogDesign guardianDialog;
    private DialogDesign dialog;

    public bool itemToken;
    private Inventory inventory;
    private void Start()
    {
        // inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        dialog = startingDialog;
        dialogText.SetText(dialog.GetDialogText());
        charName.SetText(dialog.GetCharacterName());
        charPortre.sprite = dialog.GetCharacterPortre();
    }

    private void Update()
    {
        ManageDialog();
    }

    public void GuardianDialog()
    {
        dialog = guardianDialog;
        dialogText.SetText(guardianDialog.GetDialogText());
        charName.SetText(guardianDialog.GetCharacterName());
        charPortre.sprite = guardianDialog.GetCharacterPortre();
    }
    
    public void NpcDialog()
    {
        dialog = startingDialog;
        dialogText.SetText(dialog.GetDialogText());
        charName.SetText(dialog.GetCharacterName());
        charPortre.sprite = dialog.GetCharacterPortre();
        Debug.Log("Buraya mı geliyor yoksa");
    }



    void ManageDialog()
    {
        var nextDialog = dialog.GetNextDialog();

        if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            dialog = nextDialog[0];
            // itemToken = dialog.ItemToken();
            dialogText.SetText(dialog.GetDialogText());
            charName.SetText(dialog.GetCharacterName());
            charPortre.sprite = dialog.GetCharacterPortre();
        }
    }

    private void ItemGained()
    {
        if (itemToken)
        {
            inventory.AddItem();
        }
    }
}
