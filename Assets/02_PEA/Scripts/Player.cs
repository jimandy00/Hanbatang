using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerState
    {
        Idle,
        Ready,
        Shoot
    }

    public PlayerState playerState = PlayerState.Idle;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Idle()
    {
        if (playerState == PlayerState.Idle)
            return;

        playerState = PlayerState.Idle;
    }

    public void Ready()
    {
        if (playerState == PlayerState.Ready)
            return;

        playerState = PlayerState.Ready;
    }

    public void Shoot()
    {
        if (playerState == PlayerState.Shoot)
            return;

        playerState = PlayerState.Shoot;
    }
}
