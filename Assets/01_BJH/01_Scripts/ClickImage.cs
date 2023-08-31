using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 클릭하면 이미지가 앞쪽으로 다가온다.
// 다가오면서 씬이 전환된다.

public class ClickImage : MonoBehaviour
{
    public Image imgGo02;
    public GameObject des;

    RectTransform img01;
    RectTransform img02;
    RectTransform img03;

    public GameObject typingGo;

    private Coroutine coroutine = null;

    float speed = 5f;

    Image color;

    Text description;

    List<RectTransform> imgList;
    
    int num;

    bool IsCliked  = false;
    bool imgState = false;
    bool isMoveToCam = false;
    bool canMove = false;
    private Vector3 dir = Vector3.zero;
    

    void Start()
    {
        //description = imgGo02.transform.GetChild(0).GetComponent<Text>();
        //description.gameObject.SetActive(false);

        des.SetActive(false);
        typingGo.SetActive(false);

        color = imgGo02.GetComponent<Image>();

        dir = Camera.main.transform.position - imgGo02.transform.position;
        dir.Normalize(); // 정규화. 벡터의 크기를 1로
    }

    void Update()
    {

        if (IsCliked == true)
        {

            if (imgGo02.rectTransform.localScale.x <= 2.5f)
            {
                ImgForward02();
                print(imgState);
            }
        }

        if (imgState == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                des.SetActive(true);
                typingGo.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                des.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                //ImgMaxSize02();
                //c = color.color;
                //StartCoroutine(CoImgMaxSize());
                MoveToCam();

            }
        }

        if (isMoveToCam)
        {
            ImgMaxSize();
        }
    }


    public void OnClickImg02()
    {
        print(IsCliked);
        if(IsCliked == false)
        {
            IsCliked = true;
        }
        else
        {
            if (!isMoveToCam && canMove)
            {
                print("movetocam");
                c = color.color;                
                isMoveToCam = true;
            }
        }
    }

    public void MoveToCam()
    {
        //if (coroutine == null)
        //{
        //    print("startcoroutine");
        //    c = color.color;
        //    coroutine = StartCoroutine(CoImgMaxSize());
        //}

        if (!isMoveToCam)
        {
            print("movetocam");
            c = color.color;
            dir = Camera.main.transform.position - imgGo02.transform.position;
            dir.Normalize(); // 정규화. 벡터의 크기를 1로
            //StartCoroutine(CoImgMaxSize());
            isMoveToCam = true;
        }
    }

    void ImgForward02()
    {
        // 선택된 이미지의 크기를 키움
        imgGo02.rectTransform.localScale += Vector3.one * Time.deltaTime;
        if (imgGo02.rectTransform.localScale.x >= 2.5f)
        {
            imgState = true;
            //IsCliked = false;
            Invoke(nameof(CanMove), 0.5f);
        }
    }

    private void CanMove()
    {
        canMove = true;
    }

    private void ImgMaxSize()
    {

        if(imgGo02.transform.position.z <= -3.5)
        {
            LobbyManager.instance.IntoPicture();
        }
        else
        {
            //print("z : " + imgGo02.transform.position.z);
            imgGo02.transform.position += dir * Time.deltaTime * speed;
            c.a -= 0.3f * Time.deltaTime;
            color.color = c;
        }
    }

    Color c;

    IEnumerator CoImgMaxSize()
    {
        print("111111111");
        Vector3 dir = Camera.main.transform.position - imgGo02.transform.position;
        dir.Normalize(); // 정규화. 벡터의 크기를 1로

        while (imgGo02.transform.position.z > -3.5)
        {
            print("22222222222");
            //print("z : " + imgGo02.transform.position.z);
            imgGo02.transform.position += dir * Time.deltaTime * speed;
            c.a -= 0.3f * Time.deltaTime;
            color.color = c;
            yield return new WaitForEndOfFrame();
        }

        print("333333333333");
        LobbyManager.instance.IntoPicture();
    }

    //void ImgMaxSize02()
    //{
    //    StartCoroutine(CoImgMaxSize());
    //}
}
