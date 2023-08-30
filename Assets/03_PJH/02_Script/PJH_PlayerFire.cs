using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PJH_PlayerFire : MonoBehaviour
{
    GameObject arrow;
    // 화살
    public GameObject arrowSimple;
    // 불화살
    public GameObject arrowFire;
    // 물화살
    public GameObject arrowWater;
    // 용화살
    public GameObject arrowDragon;
    // 퍼펙트 존 파워게이지
    private int powerGauge = 0;
    // 화살 나가는곳
    public Transform firePosition;
    // 화살 속도 (성공/실패)
    private int arrowSpeed = 20;
    // 임시 게이지
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
        //좌클릭시 발사
        if (Input.GetButtonDown("Fire1"))
        {
            //arrow 발사
            GameObject g = Instantiate(arrow);
            g.transform.position = firePosition.position;
            g.transform.forward = firePosition.forward;

            //게이지가 40 이상 60 이하일때 퍼펙트
            if (cube.transform.position.y > 40 && cube.transform.position.y < 60) 
            {
                g.GetComponent<PJH_Arrow>().speed = 20;
                print("명중입니다!!");
                // 성공했다는 코드 작성
            }
            else
            {
                g.GetComponent<PJH_Arrow>().speed = 10;
                print("실패입니다!!");
                // 실패했다는 코드 작성
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
