using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typing : MonoBehaviour
{
    string desIn = "�ѱ��� Ȱ���� �ſ� ������ ������ ������ �ֽ��ϴ�. ��� �ô���� �������� �������� ���Ǿ�����, ���������� Ȱ��⸦ �߿��� ���� ���� �����Ͽ����ϴ�. �̷� ������ �Ĵ뿡�� �̾���, �����ô뿡�� Ȱ��Ⱑ ���� �� ����� ���õ� �߿��� ������ �Ͽ����ϴ�. ���� Ȱ���� ���м��� ���߷��� �䱸�ϴ� �������� �νĵǸ�, 2020�� 7�� 30�Ͽ� ����������ȭ�� 142ȣ�� �����Ǿ����ϴ�. ";
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
