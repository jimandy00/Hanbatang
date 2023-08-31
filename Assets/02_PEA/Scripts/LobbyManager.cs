using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager instance = null;

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

    public void IntoPicture()
    {
        FadeInOut.instance.FadeInOrOut(false, () => SceneManager.LoadScene(1));
    }
}
