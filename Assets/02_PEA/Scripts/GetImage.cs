using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEditor;

public class GetImage : MonoBehaviour
{
    private Image downloadImage;
    private Texture2D tex;

    private void Start()
    {
        //StartCoroutine(RefreshAssetData());
        downloadImage = GetComponent<Image>();
    }

    private void Update()
    {
        ShowReceivedFile();
    }

    private void ShowReceivedFile()
    {
        tex = Resources.Load("received_file") as Texture2D;
        if (tex != null)
        {
            downloadImage.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
        }
    }

    IEnumerator RefreshAssetData()
    {
        while (true)
        {
            print("refresh");
            AssetDatabase.Refresh();
            yield return new WaitForSeconds(1f);
        }
    }
}

