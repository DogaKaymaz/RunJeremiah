using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public InventoryItemData data;
    private Image slotImage;
    private LevelInformation levelInformation;
    private void Start()
    {
        levelInformation = GameObject.Find("LevelInformation").GetComponent<LevelInformation>();
        slotImage = GetComponent<Image>();
    }

    public void AppearItem()
    {
        data = levelInformation.GetItem();
        slotImage.GameObject().SetActive(true);
        slotImage.sprite = data.icon;
    }
}
