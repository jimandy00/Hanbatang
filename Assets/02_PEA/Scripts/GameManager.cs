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
        FadeInOut.instance.FadeInOrOut(true);
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
    }

    public void Failure()
    {
        PEA_UIManager.instance.ShowResultText(false);
    }

    public void GameOver()
    {
        isStart = false;
    }

    public void IntoPicture()
    {

    }

    public void GoToLobby()
    {
        FadeInOut.instance.FadeInOrOut(false, () => SceneManager.LoadScene(0));
    }
}
