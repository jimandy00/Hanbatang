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
                // �̹��� ���� �Լ� ȣ���ϱ�
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
