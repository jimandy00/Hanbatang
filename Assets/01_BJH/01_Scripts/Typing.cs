using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typing : MonoBehaviour
{
    string desIn = "한국의 활쏘기는 매우 오래된 전통을 가지고 있습니다. 고대 시대부터 군사적인 목적으로 사용되었으며, 고구려에서는 활쏘기를 중요한 국가 행사로 간주하였습니다. 이런 전통은 후대에도 이어져, 조선시대에는 활쏘기가 무예 및 국방과 관련된 중요한 역할을 하였습니다. 현재 활쏘기는 정밀성과 집중력을 요구하는 스포츠로 인식되며, 2020년 7월 30일에 국가무형문화재 142호로 지정되었습니다. ";
    string desOut;

    public Text des;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoDes());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CoDes()
    {
        print(des.text);
        for (int i =0; i < desIn.Length; i++)
        {
            desOut += desIn[i];
            des.text = desOut;
            yield return new WaitForSeconds(Time.deltaTime * 10);
        }
        print(des.text);
        
    }
}
