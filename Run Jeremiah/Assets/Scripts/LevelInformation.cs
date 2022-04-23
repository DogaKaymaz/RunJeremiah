using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInformation : MonoBehaviour
{
    [Header("Level Information")]
    [SerializeField] private float thisLevel;
    [SerializeField] private float keysNumberNeeded;


    public float GetKeysNumberNeeded()
    {
        return keysNumberNeeded;
    }

    public float GetLevel()
    {
        return thisLevel;
    }
}