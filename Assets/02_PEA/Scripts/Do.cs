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
        if (data.Contains("1") || data.Contains("2"))
        {
            player.ChangeArrow(int.Parse(data));
        }
        else
        {
            switch (data)
            {
                case "start":
                    print("start");
                    clickImage.OnClickImg02();
                    break;

                case "ready":
                    if (player != null)
                    {
                        player.Ready();
                    }
                    break;

                case "shot":
                    if (player != null)
                    {
                        player.Shot();
                    }
                    break;

                case "change":
                    if (player != null)
                    {
                        player.ChangeArrow();
                    }
                    break;
            }
        }
    }

    public string data;

    public void GetData(string data2)
    {
        data = data2;        
    }
}
