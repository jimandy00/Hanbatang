using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (data.Contains("1") || data.Contains("2") || data.Contains("3") || data.Contains("4"))
        {
            player.ChangeArrow(int.Parse(data));
        }
        else
        {
            switch (data)
            {
                case "start":
                    // 이미지 선택 함수 호출하기
                    if(SceneManager.GetActiveScene().buildIndex == 0)
                        clickImage.OnClickImg02();
                    else
                    {
                        GameManager.instance.GoToLobby();
                    }
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
                    player.ChangeArrow();
                    break;
            }
        }
    }
}
