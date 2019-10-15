using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataModels;

public class ModelRenderTextureComponent : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> modelList = new List<GameObject>();
    private GameObject currentModel;

    /// <summary>
    /// TODONOTES:
    /// since this is a live render we can also do alternate colors and costumes
    /// this means two instances of the model needs to be live
    /// or however many max players there will be
    /// currently just have all 4 models in the scene to not have to load
    /// multi instance means (character roster * max players) so this can get pretty fat.
    /// add on variants of costumes and then we get more. we could resource load on the fly
    /// it probably wouldn't take that long
    ///
    /// alt skins = swap textures
    /// </summary>
    /// <param name="characterData"></param>
    public void SwitchCharacterModel(int playerIndex, CharacterData characterData)
    {
        Debug.Log("switching model to: " + characterData.character.ToString());
        int characterIndex = 0;
        switch (characterData.character)
        {
            case CharacterList.chara_id_00:
                characterIndex = 0;
                break;

            case CharacterList.chara_id_01:
                characterIndex = 1;
                break;

            case CharacterList.chara_id_02:
                characterIndex = 2;
                break;

            case CharacterList.chara_id_03:
                characterIndex = 3;
                break;
        }

        if (modelList[characterIndex] != currentModel)
        {
            modelList[characterIndex].SetActive(true);
            if (currentModel != null) currentModel.SetActive(false);
            currentModel = modelList[characterIndex];
        }
    }
}
