using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataModels;

public class CharacterSelectScreen : MonoBehaviour
{

    //temp, use json instantiation maybe? or a static list
    public List<CharacterData> characters = new List<CharacterData>();
    public GameObject characterCellObj;
    public Transform gridTransform;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            InstantiateCharacterCell(characters[i]);
        }
    }

    private void InstantiateCharacterCell(CharacterData charData)
    {
        GameObject charCell = Instantiate(characterCellObj, gridTransform);
        CharacterCellComponent charCellComp = charCell.GetComponent<CharacterCellComponent>();
        charCellComp.InstantiateImage(charData);
    }
}
