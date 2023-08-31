using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Ŭ���ϸ� �̹����� �������� �ٰ��´�.
// �ٰ����鼭 ���� ��ȯ�ȴ�.

public class ClickImage : MonoBehaviour
{
    public Image imgGo02;
    public GameObject des;

    RectTransform img01;
    RectTransform img02;
    RectTransform img03;


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
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                des.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                // ���� ����
            }

        }
    }


    public void OnClickImg02()
    {
        IsCliked = true;

    }

    void ImgForward02()
    {

        // ���õ� �̹����� ũ�⸦ Ű��
        imgGo02.rectTransform.localScale += Vector3.one * Time.deltaTime;
        if (imgGo02.rectTransform.localScale.x >= 2.5f)
        {
            imgState = true;
            IsCliked = false;
        }
    }


}
