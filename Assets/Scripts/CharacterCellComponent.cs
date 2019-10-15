using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCellComponent : MonoBehaviour
{
    [SerializeField]
    private Image iconImage;
    public string characterName;

    public CharacterData charData;

    public void InstantiateImage(CharacterData newCharData)
    {
        charData = newCharData;
        iconImage.sprite = charData.sprite;
        characterName = charData.name;

        Vector2 pixelSize = new Vector2(charData.sprite.texture.width, charData.sprite.texture.height);
        Vector2 pixelPivot = charData.sprite.pivot;
        Vector2 uiPivot = new Vector2(pixelPivot.x / pixelSize.x, pixelPivot.y / pixelSize.y);

        iconImage.GetComponent<RectTransform>().pivot = uiPivot;
        iconImage.GetComponent<RectTransform>().sizeDelta *= charData.spriteZoomMulti;
    }
}
