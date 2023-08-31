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

//    // 오퍼시티 값을 변경
//    IEnumerator CoBlink()
//    {
//        if(colorA == false)
//        {
//            color.a = 0.1f;
//            yield return new WaitForSeconds(1.0f);
//            print("오퍼시티값을 0.1로 변경했습니다.");
//            colorA = true;
//        }
//        else
//        {
//            color.a = 1.0f;
//            yield return new WaitForSeconds(1.5f);
//            print("오퍼시티값을 1.0으로 변경했습니다.");
//            colorA = false;
//        }




//    }
//}
