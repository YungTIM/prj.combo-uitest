using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;

using Rewired;

public class CursorDetection : MonoBehaviour
{
    [System.NonSerialized]
    public int playerId;

    private GraphicRaycaster gr;
    private PointerEventData pointerEventData = new PointerEventData(null);

    public CharacterCellComponent currentCharacter;

    public Transform token;
    public bool hasToken;

    private Player player; // The Rewired Player
    private bool inputConfirm;
    private bool inputCancel;

    // Start is called before the first frame update
    void Start()
    {
        gr =  GetComponentInParent<GraphicRaycaster>();
        player = ReInput.players.GetPlayer(playerId);
    }

    void Update()
    {
        HandleInput();

        if (hasToken)
        {
            token.position = transform.position;
            HandleCharSelect();
        }
    }

    private void HandleInput()
    {
        inputConfirm = player.GetButtonUp("Confirm");
        inputCancel = player.GetButtonUp("Cancel");

        //CONFIRM
        if (inputConfirm)
        {
            if (currentCharacter != null)
            {
                TokenFollow(false);
                CharacterSelectScreen.instance.ConfirmCharacter(playerId, CharacterSelectScreen.instance.characters[(int)currentCharacter.charData.character]);
            }
        }

        //CANCEL
        if (inputCancel)
        {
            CharacterSelectScreen.instance.confirmedCharacter[playerId] = null;
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
            if (currentCharacter != ccc || currentCharacter == null)
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
