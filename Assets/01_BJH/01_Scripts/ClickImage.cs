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

    float speed = 5f;

    Image color;

    Text description;

    List<RectTransform> imgList;
    
    int num;

    bool IsCliked  = false;
    bool imgState = false;

    void Start()
    {
        //description = imgGo02.transform.GetChild(0).GetComponent<Text>();
        //description.gameObject.SetActive(false);

        des.SetActive(false);
        typingGo.SetActive(false);

        color = imgGo02.GetComponent<Image>();

        
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
                c = color.color;
                StartCoroutine(CoImgMaxSize());

            }

        }
    }


    public void OnClickImg02()
    {
        IsCliked = true;

    }

    void ImgForward02()
    {

        // 선택된 이미지의 크기를 키움
        imgGo02.rectTransform.localScale += Vector3.one * Time.deltaTime;
        if (imgGo02.rectTransform.localScale.x >= 2.5f)
        {
            imgState = true;
            IsCliked = false;
        }
    }

    Color c;

    IEnumerator CoImgMaxSize()
    {
        Vector3 dir = Camera.main.transform.position - imgGo02.transform.position;
        dir.Normalize(); // 정규화. 벡터의 크기를 1로

        while (imgGo02.transform.position.z > -3.5)
        {
            //print("z : " + imgGo02.transform.position.z);
            imgGo02.transform.position += dir * Time.deltaTime * speed;
            c.a -= 0.3f * Time.deltaTime;
            color.color = c;
            yield return new WaitForEndOfFrame();
        }

        LobbyManager.instance.IntoPicture();
    }

    //void ImgMaxSize02()
    //{
    //    StartCoroutine(CoImgMaxSize());
    //}


}
