using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject scoreBoard;
    public GameObject score01;
    public GameObject score02;

    public GameObject fianlScoreCheckBoard;
    public Text curScoreTxt;

    int cnt = 0;

    void Start()
    {
        fianlScoreCheckBoard.SetActive(false);
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
            print("변지환 : 점수 5개가 모두 노출되었습니다.");
        }
        
        if(Input.GetKeyDown(KeyCode.T))
        {
            // 변경하기
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

    // 최종 점수 확인
    public void CheckTotalScore(int n)
    {
        fianlScoreCheckBoard.SetActive(true);
        curScoreTxt.text = n.ToString();
    }

    // 최종 점수 UI 멋지게 등장하기
    IEnumerator coCTS()
    {
        while(
        yield return null;
    }
}
