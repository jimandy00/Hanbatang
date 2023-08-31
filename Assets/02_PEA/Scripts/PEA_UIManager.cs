using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PEA_UIManager : MonoBehaviour
{
    public static PEA_UIManager instance = null;

    private readonly float scaleSpeed = 3f;
    private readonly float overScale = 1.2f;
    private readonly float targetScale = 1f;

    private Coroutine coroutine = null;

    public GameObject successText;
    public GameObject failureText;
    public Canvas canvas;

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

    void Start()
    {
        ShowResultText(true);
    }

    void Update()
    {
        
    }

    public void ShowResultText(bool isSuccess)
    {
        if (coroutine != null)
            return;

         coroutine = StartCoroutine(IShowResultText(isSuccess ? successText : failureText));
    }

    IEnumerator IShowResultText(GameObject targetText)
    {
        while(targetText.transform.localScale.x < overScale)
        {
            targetText.transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame() ;
        }

        while(targetText.transform.localScale.x > targetScale)
        {
            targetText.transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(0.5f);

        while (targetText.transform.localScale.x < overScale)
        {
            targetText.transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        while (targetText.transform.localScale.x > 0f)
        {
            targetText.transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        coroutine = null;
        yield return null;
    }
}
