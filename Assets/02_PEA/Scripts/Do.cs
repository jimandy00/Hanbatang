using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임시작 - Start
// 준비 - Ready
// 쏘기 - Shoot
// 화살 변경 - Change

public class Do : MonoBehaviour
{
    public static Do instance = null;

    private Player player = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GetData(string data)
    {
        switch (data)
        {
            case "Start":
                // 이미지 선택 함수 호출하기
                break;

            case "Ready":
                if(player != null)
                {
                    player.Ready();
                }
                break;

            case "Shoot":
                if(player != null)
                {
                    player.Shoot();
                }
                break;

            case "Change":
                break;
        }
    }
}
