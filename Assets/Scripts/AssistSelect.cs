﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;
using DG.Tweening; //the info panel needs to tween into place when selected

public class AssistSelect : MonoBehaviour
{
    public int playerId = 0;

    public List<Image> baseColor = new List<Image>();
    public List<GameObject> activePanels = new List<GameObject>();

    [SerializeField]
    private int currentIndex = 1;

    private Player player; // The Rewired Player

    //buttons
    /*
    private bool dpadup;
    private bool dpaddown;

    private bool inputConfirm;
    private bool inputCancel;
    */

    //anim data
    private const float tweenDist = -250f;
    private const float tweenTime = 0.5f;

    private bool isHidden = true;


    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerId);
    }

    private void OnEnable()
    {
        //tween in
        Sequence s = DOTween.Sequence();

        //dumb ternary crap for swiping left or right
        int direction = playerId % 2 == 1 ? -1 : 1;

        s.Append(transform.DOLocalMoveX(direction * tweenDist, 0));
    }

    // Update is called once per frame
    /*
    void Update()
    {
        if (isHidden) return;
        dpadup = player.GetButtonUp(GameConstants.input_dpad_up);
        dpaddown = player.GetButtonUp(GameConstants.input_dpad_down);

        if (dpadup)
            currentIndex = currentIndex == 0 ? 0 : --currentIndex;
        else if (dpaddown)
            currentIndex = currentIndex == 2 ? 2 : ++currentIndex;

        if (dpadup || dpaddown)
        {
            ChangeSelected();
        }

        inputConfirm = player.GetButtonUp(GameConstants.input_confirm);
        //inputCancel = player.GetButtonUp(GameConstants.input_cancel);

        if (inputConfirm)
        {
            HidePanel();
        }
    }
    */

    private void ChangeSelected()
    {
        for (int i = 0; i < 3; i++)
        {
            if (currentIndex == i)
            {
                activePanels[i].SetActive(true);
                baseColor[i].color = new Color(baseColor[i].color.r, baseColor[i].color.g, baseColor[i].color.b, 1f);
            }
            else
            {
                activePanels[i].SetActive(false);
                baseColor[i].color = new Color(baseColor[i].color.r, baseColor[i].color.g, baseColor[i].color.b, 0.6f);
            }
        }
    }

    public void ShowPanel()
    {
        if (!isHidden)
        { 
            HidePanel();
            //set that shit somewhere
            Debug.Log(currentIndex + "-ism Selected");
            return;
        }

        isHidden = false;

        currentIndex = 1;
        ChangeSelected();

        //tween in
        Sequence s = DOTween.Sequence();

        //dumb ternary crap for swiping left or right
        int direction = playerId % 2 == 1 ? -1 : 1;

        s.Append(transform.DOLocalMoveX(direction * tweenDist, 0));
        s.Append(transform.DOLocalMoveX(0, tweenTime).SetEase(Ease.OutCubic));
    }

    public void HidePanel()
    {
        if (isHidden) return;
        isHidden = true;
        
        //tween out
        Sequence s = DOTween.Sequence();

        //dumb ternary crap for swiping left or right
        int direction = playerId % 2 == 1 ? -1 : 1;

        s.Append(transform.DOLocalMoveX(0, 0));
        s.Append(transform.DOLocalMoveX(direction * tweenDist, tweenTime).SetEase(Ease.OutCubic));
    }

    //////
    ///
    /*
     * uhh make component for panels associated with the assist select component
     * when hovered over we can send a message and tell the asssist thing which one we're selecting
     * bubuhbubas
     */
}
