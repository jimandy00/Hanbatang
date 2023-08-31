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
    
    // ȭ�� �����°�
    public Transform firePosition;
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
    public AudioSource audioSource01; // Ȱ ����
    public AudioSource audioSource02; // Ȱ ���


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

    public  void ShootArrow()
    {
        //��Ŭ���� �߻� (�翷���� �ɴ�)
        if (Input.GetButtonDown("Fire1"))
        {
            audioSource02.Play();
            GameManager.instance.Shoot();
            //�������� 0.55 �̻� 0.74 �����϶� ����Ʈ
            if (point.value >= 0.55 && point.value <= 0.74) 
            {
                float n = 70;
                g.GetComponent<PJH_Arrow>().Shoot(n);
                print("�����Դϴ�!!");
                // �����ߴٴ� �ڵ� �ۼ�
                GameManager.instance.Success();
            }
            else
            {
                float n = 20;
                g.GetComponent<PJH_Arrow>().Shoot(n);
                print("�����Դϴ�!!");
                // �����ߴٴ� �ڵ� �ۼ�
                GameManager.instance.Failure();
            }

            B = false;
            // �ڵ� ������
            Invoke(nameof(Reload), 3);

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
        
        
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            B = true;
            currentTime = 0;
            point.value = 0;
            audioSource01.Play();
        }

    }

    private void Reload()
    {
        g = Instantiate(arrow);
        g.transform.position = firePosition.position;
        
        //g.transform.forward = firePosition.forward;
        
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Reload));
    }
}
