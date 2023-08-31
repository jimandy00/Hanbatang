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
    
    // 화살 나가는곳
    public Transform firePosition;
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
    public AudioSource audioSource01; // 활 당기기
    public AudioSource audioSource02; // 활 쏘기


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
        //좌클릭시 발사 (양옆으로 핀다)
        if (Input.GetButtonDown("Fire1"))
        {
            audioSource02.Play();
            GameManager.instance.Shoot();
            //게이지가 0.55 이상 0.74 이하일때 퍼펙트
            if (point.value >= 0.55 && point.value <= 0.74) 
            {
                float n = 70;
                g.GetComponent<PJH_Arrow>().Shoot(n);
                print("명중입니다!!");
                // 성공했다는 코드 작성
                GameManager.instance.Success();
            }
            else
            {
                float n = 20;
                g.GetComponent<PJH_Arrow>().Shoot(n);
                print("실패입니다!!");
                // 실패했다는 코드 작성
                GameManager.instance.Failure();
            }

            B = false;
            // 자동 재장전
            Invoke(nameof(Reload), 3);

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
