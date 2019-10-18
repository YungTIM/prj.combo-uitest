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

    public Transform token;
    public bool hasToken;

    // Start is called before the first frame update
    void Start()
    {
        gr =  GetComponentInParent<GraphicRaycaster>();
    }

    void Update()
    {
        if (hasToken)
        {
            token.position = transform.position;
        }

        HandleCharSelect();
    }

    private void HandleInput()
    {
        //CONFIRM
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentCharacter != null)
            {
                TokenFollow(false);
                CharacterSelectScreen.instance.ConfirmCharacter(0, CharacterSelectScreen.instance.characters[(int)currentCharacter.charData.character]);
            }
        }

        //CANCEL
        if (Input.GetKeyDown(KeyCode.X))
        {
            CharacterSelectScreen.instance.confirmedCharacter = null;
            TokenFollow(true);
        }
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

    void TokenFollow(bool trigger)
    {
        hasToken = trigger;
    }
}
