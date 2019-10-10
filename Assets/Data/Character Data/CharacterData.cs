using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataModels;

[System.Serializable]
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacterData", order = 1)]
public class CharacterData : ScriptableObject
{
    public CharacterList character;
    public Sprite sprite;
    public float spriteZoomMulti = 1;
    public string description;
}
