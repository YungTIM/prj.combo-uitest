﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CharacterSelectScreen : MonoBehaviour
{
    public static CharacterSelectScreen instance;

    //temp, use json instantiation maybe? or a static list
    public List<CharacterData> characters = new List<CharacterData>();
    public GameObject characterCellObj;
    public Transform gridTransform;

    public List<CharacterData> confirmedCharacter = new List<CharacterData>();

    [SerializeField]
    private Image[] portraits;
    [SerializeField]
    private Image[] nameLogos;
    [SerializeField]
    private ModelRenderTextureComponent[] mrtComponent;
    [SerializeField]
    private AssistSelect[] assistSelectComponent;

    private void Awake()
    {
        instance = this;
    }

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

    public void ShowCharacterInSlot(int playerIndex, CharacterData character, int spriteIndex)  {
        bool nullChar = (character == null);
        portraits[playerIndex].GetComponent<Image>().sprite = character.sprite[spriteIndex];
        nameLogos[playerIndex].GetComponent<Image>().sprite = character.charLogo;
        PortraitSwipe(playerIndex);
        mrtComponent[playerIndex].SwitchCharacterModel(playerIndex, character);
    }

    private void PortraitSwipe(int playerIndex)
    {
        Transform portraitTransform = portraits[playerIndex].transform;
        Sequence s = DOTween.Sequence();

        //dumb ternary crap for swiping left or right
        int direction = playerIndex % 2 == 1 ? -1 : 1;

        s.Append(portraitTransform.DOLocalMoveX(direction * -150, 0));
        s.Append(portraitTransform.DOLocalMoveX(0, .1f).SetEase(Ease.OutCubic));
    }

    public void ConfirmCharacter(int playerIndex, CharacterData charData)
    {
        confirmedCharacter[playerIndex] = charData;
        if (charData == null)
            assistSelectComponent[playerIndex].HidePanel();
        else
            assistSelectComponent[playerIndex].ShowPanel();
    }
}
