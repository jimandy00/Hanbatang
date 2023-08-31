using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        switch (data)
        {
            case "start":
                // �̹��� ���� �Լ� ȣ���ϱ�
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
