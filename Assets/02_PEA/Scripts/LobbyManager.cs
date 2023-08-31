using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager instance = null;

    public GameObject obj;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActiveObj();
        }
    }

    public void ActiveObj()
    {
        obj.SetActive(true);
    }

    public void IntoPicture()
    {
        //FadeInOut.instance.FadeInOrOut(false, () => print("fadein"));
        FadeInOut.instance.FadeInOrOut(false, () => SceneManager.LoadScene(1));
    }
}
