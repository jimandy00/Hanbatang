using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GetImage : MonoBehaviour
{
    private Image downloadImage;

    private void Start()
    {
        downloadImage = GetComponent<Image>();
        OnClickGetImage();
    }


    public void PostTest()
    {
        HttpInfo info = new HttpInfo();
        info.Set(RequestType.POST, "/sign_up", (DownloadHandler downloadHandler) =>
        {

        });

        SignUpInfo signUpInfo = new SignUpInfo();
        signUpInfo.userName = "¹ÚÀº¾Æ";
        signUpInfo.birthday = "20020509";
        signUpInfo.age = 22;

        info.body = JsonUtility.ToJson(signUpInfo);

        HttpManager.Get().SendRequest(info);
    }

    public void OnClickGetImage()
    {
        //https://jsonplaceholder.typicode.com/photos

        HttpInfo info = new HttpInfo();
        info.Set(RequestType.TEXTURE, "https://img.seoul.co.kr/img/upload/2021/09/17/SSI_20210917150355.jpg", OnCompleteDownloadTexture, false);

        HttpManager.Get().SendRequest(info);
    }

    private void OnCompleteDownloadTexture(DownloadHandler downloadHandler)
    {
        Texture2D texture = ((DownloadHandlerTexture)downloadHandler).texture;

        downloadImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        downloadImage.preserveAspect = true;
    }
}

