using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int shootCount = 0;
    private int successCount = 0;
    private readonly int shootChance = 5;
    private bool isStart = false;

    public Player player;
    public Score score;
    public PJH_PlayerFire playerFire;
    public GameObject gauge;

    public int SuccessCount
    {
        get { return successCount; }
    }

    public bool IsStart
    {
        get { return isStart; }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //FadeInOut.instance.FadeInOrOut(true);
        Do.instance.GetPlayer(player);
    }

    public Player GameStart()
    {
        if (isStart)
            return null;

        isStart = true;

        return player;
    }

    public void Shoot()
    {
        print("gm shoot");
        shootCount++;
        if(shootCount >= shootChance)
        {
            GameOver();
        }
    }

    public void Success()
    {
        successCount++;
        PEA_UIManager.instance.ShowResultText(true);
        score.O();
    }

    public void Failure()
    {
        PEA_UIManager.instance.ShowResultText(false);
        score.X();
    }

    public void GameOver()
    {
        isStart = false;
        playerFire.enabled = false;
        gauge.SetActive(false);
        score.CheckTotalScore(successCount);
    }

    public void IntoPicture()
    {

    }

    public void GoToLobby()
    {
        FadeInOut.instance.FadeInOrOut(false, () => SceneManager.LoadScene(0));
    }
}
