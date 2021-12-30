using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class KeysCounter : MonoBehaviour
{
   public TextMeshProUGUI counterText;
   private float counter;

   private void Awake()
   {
      counterText = GetComponentInChildren<TextMeshProUGUI>();
   }

   private void FixedUpdate()
   {
      counterText.SetText(counter.ToString());
   }

   public void IncreaseCounter()
   {
      counter += 1;
      Debug.Log("Increased.");
   }
   
   
}
