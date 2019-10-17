using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorComponent : MonoBehaviour
{
    private enum PlayerIndex { player_one, player_two, player_three, player_four }
    [SerializeField]
    private PlayerIndex playerIndex;

    private CursorMovement cursorMovement;
    private CursorDetection cursorDetection;

    void Start ()
    {
        cursorMovement = gameObject.AddComponent<CursorMovement>();
        cursorMovement.playerId = (int)playerIndex;
        cursorDetection = gameObject.AddComponent<CursorDetection>();
        cursorDetection.playerId = (int) playerIndex;

    }
}
