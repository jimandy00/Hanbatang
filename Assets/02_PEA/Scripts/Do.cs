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
    public ClickImage clickImage;

    private bool isUpdate = false;

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

    private void Start()
    {

    }

    public void GetPlayer(Player p)
    {
        player = p;
        print("get Player");
    }

    private void Update()
    {
        if (isUpdate)
        {
            if (data.Contains("기본"))
            {
                player.ChangeArrow(1);
                isUpdate = false;
            }
            else if (data.Contains("fire")){
                player.ChangeArrow(2);
                isUpdate = false;
            }
            else
            {
                switch (data)
                {
                    case "start":
                        isUpdate = false;
                        if(SceneManager.GetActiveScene().buildIndex == 0)
                        {
                            clickImage.OnClickImg02();
                        }
                        else if(SceneManager.GetActiveScene().buildIndex == 1)
                        {
                            GameManager.instance.GoToLobby();
                        }
                        break;

                    case "ready":
                        isUpdate = false;
                        if (player != null)
                        {
                            player.Ready();
                        }
                        break;

                    case "shot":
                        isUpdate = false;
                        if (player != null)
                        {
                            player.Shot();
                        }
                        break;

                    case "change":
                        isUpdate = false;
                        if (player != null)
                        {
                            player.ChangeArrow();
                        }
                        break;
                }
            }
        }
    }

    public string data;

    public void GetData(string data2)
    {
        data = data2;
        isUpdate = true;
    }
}
