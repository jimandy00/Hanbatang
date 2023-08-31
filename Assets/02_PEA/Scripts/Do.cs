using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ���ӽ��� - Start
// �غ� - Ready
// ��� - Shoot
// ȭ�� ���� - Change

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
                    // �̹��� ���� �Լ� ȣ���ϱ�
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
