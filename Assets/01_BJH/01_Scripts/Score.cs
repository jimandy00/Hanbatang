using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float scaleSpeed = 1f;
    private float targetScale = 1f;
    private float overScale = 1.2f;
    private float rotateSpeed = 1050f;

    public GameObject scoreBoard;
    public GameObject score01;
    public GameObject score02;

    public GameObject fianlScoreCheckBoard;
    public Text curScoreTxt;

    int cnt = 0;

    void Start()
    {
        //fianlScoreCheckBoard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(cnt < 5)
        {
            if(Input.GetKeyDown(KeyCode.O))
            {
                O();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                X();
            }
        }
        else
        {
            print("����ȯ : ���� 5���� ��� ����Ǿ����ϴ�.");
        }
        
        if(Input.GetKeyDown(KeyCode.T))
        {
            // �����ϱ�
            CheckTotalScore(3);
        }

    }

    // O
    public void O()
    {
        Instantiate(score01, scoreBoard.transform);
        cnt++;
    }
        
    // X
    public void X()
    {
        Instantiate(score02, scoreBoard.transform);
        cnt++;
    }

    // ���� ���� Ȯ��
    public void CheckTotalScore(int n)
    {
        //fianlScoreCheckBoard.SetActive(true);
        curScoreTxt.text = n.ToString();
        StartCoroutine(coCTS());
    }

    // ���� ���� UI ������ �����ϱ�
    IEnumerator coCTS()
    {
        Vector3 eulerAngle = fianlScoreCheckBoard.transform.eulerAngles;
        while (fianlScoreCheckBoard.transform.localScale.x < overScale)
        {
            fianlScoreCheckBoard.transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
            eulerAngle.z += rotateSpeed * Time.deltaTime;
            fianlScoreCheckBoard.transform.eulerAngles = eulerAngle;
            yield return new WaitForEndOfFrame();
        }

        fianlScoreCheckBoard.transform.eulerAngles = Vector3.zero;

        while (fianlScoreCheckBoard.transform.localScale.x > targetScale)
        {
            fianlScoreCheckBoard.transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }
}
