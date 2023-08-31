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
    private ClickImage clickImage;

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
            case "start":
                // 이미지 선택 함수 호출하기
                clickImage.OnClickImg02();
                break;

            case "ready":
                if(player != null)
                {
                    player.Ready();
                }
                break;

            case "shot":
                if(player != null)
                {
                    player.Shot();
                }
                break;

            case "change":
                break;
        }
    }
}
