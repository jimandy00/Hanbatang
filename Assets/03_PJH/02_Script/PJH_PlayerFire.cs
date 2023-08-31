using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PJH_PlayerFire : MonoBehaviour
{
    GameObject g;
    GameObject arrow;
    // 화살
    public GameObject arrowSimple;
    // 불화살
    public GameObject arrowFire;
    // 물화살
    public GameObject arrowWater;
    // 용화살
    public GameObject arrowDragon;
    // 화살 나가는곳
    public Transform firePosition;
    // 화살 속도 (성공/실패)
    private int arrowSpeed = 20;
    // 임시 게이지
    public Scrollbar point;
    // 화살이 장전되었는가?
    bool B = false;
    // PerfectZone 초기화
    float currentTime = 0;
    // 게임시작 - Start
    // 준비 - Ready
    // 쏘기 - Shot
    // 화살 변경 - Change

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
        //좌클릭시 발사 (양옆으로 핀다)
        if (Input.GetButtonDown("Fire1"))
        {
            //게이지가 0.6 이상 0.7 이하일때 퍼펙트
            if (point.value >= 0.6 && point.value <= 0.7) 
            {
                float n = 50;
                g.GetComponent<PJH_Arrow>().Shoot(n);
                print("명중입니다!!");
                // 성공했다는 코드 작성
            }
            else
            {
                float n = 10;
                g.GetComponent<PJH_Arrow>().Shoot(n);
                print("실패입니다!!");
                // 실패했다는 코드 작성
            }

            B = false;
            // 자동 재장전
            Invoke(nameof(Reload), 4);

        }
    }

    
    //PerfectZone 움직이는 함수
    IEnumerator PerfectZone()
    {
        if (B == true)
        {
            currentTime += Time.deltaTime;
            point.value = Mathf.PingPong(currentTime, 0.943f);
            
            yield return new WaitForSecondsRealtime(0.01f);
        }        
    }
    
    //화살 종류 선택
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
