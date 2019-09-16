using UnityEngine;
using UnityEngine.UI;
using DataModels;

/// <summary>
/// Extendable class for a screen which handles animations and transitions
/// </summary>
public class ScreenAnimatorHandler : MonoBehaviour
{
    [SerializeField]
    protected DisplayScreen myScreen;

    [SerializeField]
    protected Animator[] animators;

    [SerializeField]
    protected Text headerText;

    void OnEnable()
    {
        UIManager.OnChangeScreen += HandleTransition;
    }

    void OnDisable()
    {
        UIManager.OnChangeScreen -= HandleTransition;
    }

    /// <summary>
    /// Handle the transition, should we show or hide this screen. Params are ints because we can't pass enums through a delegate
    /// </summary>
    /// <param name="oldScreen"></param>
    /// <param name="newScreen"></param>
    private void HandleTransition(int oldScreen, int newScreen)
    {
        if ((int)myScreen == oldScreen)
        {
            Hide();
        }
        else if ((int)myScreen == newScreen)
        {
            Show();
        }
    }

    public void Hide()
    {
        TogglePanelAnimator(false, animators);
    }

    public void Show()
    {
        TogglePanelAnimator(true, animators);
        OnShow();
        SetHeaderText();
    }

    private void TogglePanelAnimator(bool toggle, Animator[] animators)
    {
        for (int i = 0; i < animators.Length; i++)
        {
            animators[i].gameObject.SetActive(true);
            animators[i].SetTrigger(toggle ? GameConstants.SHOW_ANIMATOR_PARAMETER : GameConstants.HIDE_ANIMATOR_PARAMETER);
        }
    }

    public virtual void OnShow()
    {
    }

    public virtual void SetHeaderText()
    {
    }
}
