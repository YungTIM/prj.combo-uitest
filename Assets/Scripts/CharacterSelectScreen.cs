using System.Collections;
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

    [SerializeField]
    private Image[] portraits;
    [SerializeField]
    private Image[] nameLogos;
    [SerializeField]
    private ModelRenderTextureComponent[] mrtComponent;

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

    public void ShowCharacterInSlot(int player, CharacterData character)  {
        bool nullChar = (character == null);
        portraits[player].GetComponent<Image>().sprite = character.sprite;
        nameLogos[player].GetComponent<Image>().sprite = character.charLogo;
        PortraitSwipe(portraits[player].transform);
        mrtComponent[player].SwitchCharacterModel(character);
    }

    private void PortraitSwipe(Transform portraitTransform)
    {
        Sequence s = DOTween.Sequence();
        s.Append(portraitTransform.DOLocalMoveX(-150, 0));
        s.Append(portraitTransform.DOLocalMoveX(0, .1f).SetEase(Ease.OutCubic));
    }
}
