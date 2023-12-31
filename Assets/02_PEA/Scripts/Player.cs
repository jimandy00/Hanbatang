using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerState
    {
        Idle,
        Ready,
        Shot,
        ChangeArrow
    }

    public PlayerState playerState = PlayerState.Idle;

    public PJH_PlayerFire playerFire;
    public GameObject changeText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Ready();
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Shot();
        }
    }

    public void Idle()
    {
        if (playerState == PlayerState.Idle)
            return;

        playerState = PlayerState.Idle;
    }

    public void Ready()
    {
        if (playerState != PlayerState.Idle && playerFire.canReady)
            return;

        playerState = PlayerState.Ready;

        print("ready");

        playerFire.Ready();
    }

    public void Shot()
    {
        if (playerState != PlayerState.Ready)
            return;

        playerState = PlayerState.Shot;

        print("shot");

        playerFire.ShootArrow();
        Idle();
    }

    public void ChangeArrow(int arrowNum = 0)
    {
        if(arrowNum == 0)
        {
            playerState = PlayerState.ChangeArrow;
            PEA_UIManager.instance.ShowChangeText();
        }
        else if (playerState == PlayerState.ChangeArrow)
        {
            playerFire.SelectArrow(arrowNum);
            playerState = PlayerState.Idle;
            PEA_UIManager.instance.DisappearChangeText();
        }
    }
}
