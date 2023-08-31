using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public static FadeInOut instance = null;

    private float fadeSpeed = 2f;
    private Coroutine coroutine = null;

    public Image fadeImage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void FadeInOrOut(bool isFadeIn, System.Action action = null)
    {
        if(coroutine == null)
        {
            coroutine = StartCoroutine(IFadeInOut(isFadeIn));
        }
    }

    IEnumerator IFadeInOut(bool isFadeIn, System.Action action = null)
    {
        Color color = fadeImage.color;
        if(isFadeIn)
        {
            while(fadeImage.color.a > 0)
            {
                color.a -= fadeSpeed * Time.deltaTime;
                fadeImage.color = color;
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            while(fadeImage.color.a < 1)
            {
                color.a += fadeSpeed * Time.deltaTime;
                fadeImage.color = color;
                yield return new WaitForEndOfFrame();
            }
        }

        coroutine = null;
        yield return action;
    }
}
