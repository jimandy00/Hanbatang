using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PJH_PlayerFire : MonoBehaviour
{
    GameObject g;
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
    // ȭ���� �����Ǿ��°�?
    bool B = false;
    // PerfectZone �ʱ�ȭ
    float currentTime = 0;
    // ���ӽ��� - Start
    // �غ� - Ready
    // ��� - Shot
    // ȭ�� ���� - Change

    void Start()
    {
        point.value = 0;
        arrow = arrowSimple;
        
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
        //��Ŭ���� �߻� (�翷���� �ɴ�)
        if (Input.GetButtonDown("Fire1"))
        {
            //�������� 0.6 �̻� 0.7 �����϶� ����Ʈ
            if (point.value >= 0.6 && point.value <= 0.7) 
            {
                float n = 50;
                g.GetComponent<PJH_Arrow>().Shoot(n);
                print("�����Դϴ�!!");
                // �����ߴٴ� �ڵ� �ۼ�
            }
            else
            {
                float n = 10;
                g.GetComponent<PJH_Arrow>().Shoot(n);
                print("�����Դϴ�!!");
                // �����ߴٴ� �ڵ� �ۼ�
            }

            B = false;
            // �ڵ� ������
            Invoke(nameof(Reload), 4);

        }
    }

    
    //PerfectZone �����̴� �Լ�
    IEnumerator PerfectZone()
    {
        if (B == true)
        {
            currentTime += Time.deltaTime;
            point.value = Mathf.PingPong(currentTime, 0.943f);
            
            yield return new WaitForSecondsRealtime(0.01f);
        }        
    }
    
    //ȭ�� ���� ����
    private void SelectArrow()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {            
            B = false;
            currentTime = 0;
            point.value = 0;
            arrow = arrowSimple;
            Reload();            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {            
            B = false;
            currentTime = 0;
            point.value = 0;
            arrow = arrowFire;
            Reload();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {          
            B = false;
            currentTime = 0;
            point.value = 0;
            arrow = arrowWater;
            Reload();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {            
            B = false;
            currentTime = 0;
            point.value = 0;
            arrow = arrowDragon;
            Reload();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            B = true;
        }

    }

    private void Reload()
    {
        g = Instantiate(arrow);
        g.transform.position = firePosition.position;
        
        //g.transform.forward = firePosition.forward;
        
    }
}
