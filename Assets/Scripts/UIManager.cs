using UnityEngine;
using UnityEngine.UI;
using DataModels;

/// <summary>
/// Class to manage switching UI screens.
/// </summary>
public class UIManager : MonoBehaviour
{
    private DisplayScreen _currentDisplayedScreen;

    public delegate void ChangeScreen(int oldScreen, int newScreen);
    public static event ChangeScreen OnChangeScreen;


    void Start()
    {
        //SwitchScreen(displ))
    }

    public void SwitchScreen(DisplayScreen screenToDisplay)
    {
        if (OnChangeScreen != null && _currentDisplayedScreen != screenToDisplay)
        {
            Debug.Log("Switching screens from " + _currentDisplayedScreen.ToString() + " to " + screenToDisplay);
        }

        OnChangeScreen((int) _currentDisplayedScreen, (int)screenToDisplay);

        _currentDisplayedScreen = screenToDisplay;
    }
}
