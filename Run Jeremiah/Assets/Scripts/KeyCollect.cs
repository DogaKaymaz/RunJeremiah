using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{
  private GameObject keysCounterObject;
  private KeysCounter keysCounterScript;

  private void Awake()
  {
    keysCounterObject = GameObject.Find("KeysCounter");
    keysCounterScript = keysCounterObject.GetComponent<KeysCounter>();
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.TryGetComponent(out JeremiahMovement jeremiahMovement))
    {
      Debug.Log("Key Collected");
      keysCounterScript.IncreaseCounter();
      Destroy(gameObject);   
    }
  }
}
