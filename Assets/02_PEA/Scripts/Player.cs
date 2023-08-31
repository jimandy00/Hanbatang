using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerState
    {
        Idle,
        Ready,
        Shot
    }

    public PlayerState playerState = PlayerState.Idle;

    public PJH_PlayerFire playerFire;

    public void Idle()
    {
        if (playerState == PlayerState.Idle)
            return;

        playerState = PlayerState.Idle;
    }

    public void Ready()
    {
        if (playerState != PlayerState.Idle)
            return;

        playerState = PlayerState.Ready;
        print("ready");
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
}
