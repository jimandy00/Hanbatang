using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 클릭하면 이미지가 앞쪽으로 다가온다.
// 다가오면서 씬이 전환된다.

public class ClickImage : MonoBehaviour
{
    public Image imgGo02;

    RectTransform img01;
    RectTransform img02;
    RectTransform img03;

    List<RectTransform> imgList;
    
    int num;

    bool IsCliked  = false;
    bool imgState = false;

    void Start()
    {
        //img02 = GameObject.Find("Image02").
        //img01 = GameObject.FindGameObjectsWithTag("Img")[0].GetComponent<RectTransform>();
        //img02 = GameObject.FindGameObjectsWithTag("Img")[1].GetComponent<RectTransform>();
        //img03 = GameObject.FindGameObjectsWithTag("Img")[2].GetComponent<RectTransform>();

        //// imgList = [img01, img02, img03]
        //imgList.Add(img01);
        //imgList.Add(img02);
        //imgList.Add(img03);
    }

    void Update()
    {

        if(IsCliked == true && imgGo02.rectTransform.localScale.x <= 2.5f)
        {

            OnClickImgForward02();
        }
    }


    public void OnClickImgForward02()
    {
        IsCliked = true;
        imgState = true;

        // 선택된 이미지의 크기를 키움
        imgGo02.rectTransform.localScale += Vector3.one * Time.deltaTime;
    }


}
