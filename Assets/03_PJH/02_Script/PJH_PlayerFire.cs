using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PJH_PlayerFire : MonoBehaviour
{
    GameObject arrow;
    // ȭ��
    public GameObject arrowSimple;
    // ��ȭ��
    public GameObject arrowFire;
    // ��ȭ��
    public GameObject arrowWater;
    // ��ȭ��
    public GameObject arrowDragon;
    // ����Ʈ �� �Ŀ�������
    private int powerGauge = 0;
    // ȭ�� �����°�
    public Transform firePosition;
    // ȭ�� �ӵ� (����/����)
    private int arrowSpeed = 20;
    // �ӽ� ������
    public Image point;
    GameObject cube;


    void Start()
    {
        arrow = arrowSimple;
        PerfectZone();
    }

    // Update is called once per frame
    void Update()
    {
        SelectArrow();
        ShootArrow();        
    }

    private void ShootArrow()
    {
        //��Ŭ���� �߻�
        if (Input.GetButtonDown("Fire1"))
        {
            //arrow �߻�
            GameObject g = Instantiate(arrow);
            g.transform.position = firePosition.position;
            g.transform.forward = firePosition.forward;

            //�������� 40 �̻� 60 �����϶� ����Ʈ
            if (cube.transform.position.y > 40 && cube.transform.position.y < 60) 
            {
                g.GetComponent<PJH_Arrow>().speed = 20;
                print("�����Դϴ�!!");
                // �����ߴٴ� �ڵ� �ۼ�
            }
            else
            {
                g.GetComponent<PJH_Arrow>().speed = 10;
                print("�����Դϴ�!!");
                // �����ߴٴ� �ڵ� �ۼ�
            }
            
            

        }
    }

    private void PerfectZone()
    {
        //point.rectTransform.position = new Vector2(Mathf.PingPong(Time.time, 240),0);
        //cube.transform.position = new Vector3( cube.transform.position.x, Mathf.PingPong(Time.time, 10), cube.transform.position.z);
    }

    private void SelectArrow()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            arrow = arrowSimple;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            arrow = arrowFire;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            arrow = arrowWater;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            arrow = arrowDragon;
        }

    }
}
