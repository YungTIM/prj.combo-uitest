using UnityEngine;
using UnityEngine.UI;
using Rewired;

/// <summary>
/// Class to manage switching UI screens.
/// </summary>
public class InputComponent : MonoBehaviour
{
    private int playedId = 0;
    private Player player; //the rewired player

    private void Awake()
    {
        player = ReInput.players.GetPlayer(playedId);
    }

    private void Update()
    {
        GetInput();
        ProcessInput();
    }

    private void GetInput()
    {

    }

    private void ProcessInput()
    {

    }
}
