//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Info : MonoBehaviour
//{
//    public Text text;
//    Color color;
//    bool colorA = false;

//    void Start()
//    {
//        color = text.color;

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        StartCoBlick();
//    }

//    void StartCoBlick()
//    {
//        StartCoroutine(CoBlink());

//    }

//    // ���۽�Ƽ ���� ����
//    IEnumerator CoBlink()
//    {
//        if(colorA == false)
//        {
//            color.a = 0.1f;
//            yield return new WaitForSeconds(1.0f);
//            print("���۽�Ƽ���� 0.1�� �����߽��ϴ�.");
//            colorA = true;
//        }
//        else
//        {
//            color.a = 1.0f;
//            yield return new WaitForSeconds(1.5f);
//            print("���۽�Ƽ���� 1.0���� �����߽��ϴ�.");
//            colorA = false;
//        }




//    }
//}
