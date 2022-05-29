using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class KeyCollect : MonoBehaviour
{
  private GameObject keysCounterObject;
  private KeysCounter keysCounterScript;
  [SerializeField] private GameObject keyPS;
  [SerializeField] private AudioClip keySound;

  private void Awake()
  {
    keysCounterObject = GameObject.Find("KeysCounter");
    keysCounterScript = keysCounterObject.GetComponent<KeysCounter>();
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.TryGetComponent(out JeremiahMovement jeremiahMovement))
    {
      AudioSource.PlayClipAtPoint(keySound, transform.position);
      Debug.Log("Key Collected");
      keysCounterScript.IncreaseCounter();
      Destroy(gameObject);
      TriggerSparkles();
    }
  }
  
  private void TriggerSparkles()
  {
    GameObject sparkles = Instantiate(
      keyPS,
      transform.position,
      transform.rotation);
    
    Destroy(sparkles, 2.5f);
  }
}
