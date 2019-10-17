using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CursorDetection : MonoBehaviour
{
    [System.NonSerialized]
    public int playerId;

    private GraphicRaycaster gr;
    private PointerEventData pointerEventData = new PointerEventData(null);

    public CharacterCellComponent currentCharacter;


    // Start is called before the first frame update
    void Start()
    {
        gr =  GetComponentInParent<GraphicRaycaster>();
    }

    void Update()
    {
        HandleCharSelect();
    }

    //temp switch to idk rewired or someshit, although i guess we should support mouse selection too
    private void HandleCharSelect()
    {
        pointerEventData.position = Camera.main.WorldToScreenPoint(transform.position);
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(pointerEventData, results);

        if (results.Count > 0)
        {
			CharacterCellComponent ccc = results[0].gameObject.GetComponent<CharacterCellComponent>();
            if (currentCharacter != ccc)
            {
                if (ccc != null)
                {
                    SetCurrentCharacter(ccc);
                    Debug.Log(ccc.characterName);
                }
            }
        }
    }

    void SetCurrentCharacter(CharacterCellComponent ccc)
    {
        currentCharacter = ccc;
        if (ccc != null)
        {
            CharacterSelectScreen.instance.ShowCharacterInSlot(playerId, ccc.charData);
        }
        else
        {
            CharacterSelectScreen.instance.ShowCharacterInSlot(playerId, null);
        }
    }
}
