using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Character")]
public class CharacterDesign : ScriptableObject
{
    [SerializeField] public Sprite characterPortre;
    [SerializeField] public string characterName;
}
