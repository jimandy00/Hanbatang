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
    // ȭ�� �����°�
    public Transform firePosition;
    // ȭ�� �ӵ� (����/����)
    private int arrowSpeed = 20;
    // �ӽ� ������
    public Scrollbar point;
    // ȭ���� �Ƚ��°�?
    bool B = false;
    //
    

    void Start()
    {
        arrow = arrowSimple;
        //PerfectZone();
        //StartCoroutine(PerfectZone());
    }

    // Update is called once per frame
    void Update()
    {
        SelectArrow();
        ShootArrow();
        StartCoroutine(PerfectZone()); 
    }

    private void ShootArrow()
    {
        //��Ŭ���� �߻�
        if (Input.GetButtonDown("Fire1"))
        {
            //arrow �߻�
                      

            //�������� 0.6 �̻� 0.7 �����϶� ����Ʈ
            if (point.value >= 0.6 && point.value <= 0.7) 
            {
                //g.GetComponent<PJH_Arrow>().speed = 50;
                print("�����Դϴ�!!");
                // �����ߴٴ� �ڵ� �ۼ�
            }
            else
            {
                //g.GetComponent<PJH_Arrow>().speed = 10;
                print("�����Դϴ�!!");
                // �����ߴٴ� �ڵ� �ۼ�
            }
            B = false;
            
        }
    }

    //PerfectZone �����̴� �Լ�
    IEnumerator PerfectZone()
    {
        if (B == true)
        {
            point.value = Mathf.PingPong(Time.time, 0.943f);
            
            yield return new WaitForSecondsRealtime(0.01f);
        }
        
    }
    
    //ȭ�� ���� ����
    private void SelectArrow()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Destroy(arrow);
            B = false;
            point.value = 0f;
            arrow = arrowSimple;
            GameObject g = Instantiate(arrow);
            g.transform.position = firePosition.position;
            B = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(arrow);
            B = false;
            point.value = 0f;
            arrow = arrowFire;
            GameObject g = Instantiate(arrow);
            g.transform.position = firePosition.position;
            B = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Destroy(arrow);
            B = false;
            point.value = 0f;
            arrow = arrowWater;
            GameObject g = Instantiate(arrow);
            g.transform.position = firePosition.position;
            B = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Destroy(arrow);
            B = false;
            point.value = 0f;
            arrow = arrowDragon;
            GameObject g = Instantiate(arrow);
            g.transform.position = firePosition.position;
            B = true;
        }

    }

    
}
