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
        downloadImage = GetComponent<Image>();
    }

    public void ShowReceivedFile(Sprite receivedSprite)
    {
        //tex = Resources.Load("received_file") as Texture2D;
        //if (tex != null)
        //{
        //    downloadImage.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
        //}

        downloadImage.sprite = receivedSprite;
    }
}

