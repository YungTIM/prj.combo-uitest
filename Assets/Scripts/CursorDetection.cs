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
    public int currentColorIndex;
    private int displayedColorIndex;

    public Transform token;
    public bool hasToken;

    private Player player; // The Rewired Player
    private bool inputConfirm;
    private bool inputCancel;

    private bool action1; //top left action button
    private bool action2; //top right action button

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
        inputConfirm = player.GetButtonUp(GameConstants.input_confirm);
        inputCancel = player.GetButtonUp(GameConstants.input_cancel);

        //CONFIRM
        if (inputConfirm)
        {

            if (currentCharacter != null && hasToken)
            {
                TokenFollow(false);
                CharacterSelectScreen.instance.ConfirmCharacter(playerId, CharacterSelectScreen.instance.characters[(int)currentCharacter.charData.character]);
            }
            else if (!hasToken)
            {
                pointerEventData.position = Camera.main.WorldToScreenPoint(transform.position);
                List<RaycastResult> results = new List<RaycastResult>();
                gr.Raycast(pointerEventData, results);

                if (results[0].gameObject.GetComponent<TokenComponent>() && results[0].gameObject.transform == token) TokenFollow(true);
            }
        }
        
        //CANCEL
        if (inputCancel)
        {
            TokenFollow(true);
            CharacterSelectScreen.instance.ConfirmCharacter(playerId, null);
        }

        action1 = player.GetButtonUp(GameConstants.input_action1);
        action2 = player.GetButtonUp(GameConstants.input_action2);

        //COLOR SWAP
        if (currentCharacter != null && hasToken)
        {
            if (action1)
            {
                currentColorIndex = currentColorIndex == 0 ? 0 : --currentColorIndex;
            }
            if (action2)
            {
                int maxIndex = currentCharacter.charData.sprite.Length - 1;
                currentColorIndex = currentColorIndex == maxIndex ? maxIndex : ++currentColorIndex;
            }
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
            if (currentCharacter != ccc || currentCharacter == null || displayedColorIndex != currentColorIndex)
            {
                if (currentCharacter != ccc) currentColorIndex = 0;
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
            CharacterSelectScreen.instance.ShowCharacterInSlot(playerId, ccc.charData, currentColorIndex);
        }
        else
        {
            CharacterSelectScreen.instance.ShowCharacterInSlot(playerId, null, currentColorIndex);
        }
        displayedColorIndex = currentColorIndex;
    }

    void TokenFollow(bool trigger)
    {
        hasToken = trigger;
        token.GetComponent<Image>().raycastTarget = !trigger;
    }
}
