using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;

public class client : MonoBehaviour
{
    private const string serverHost = "192.168.1.24"; // Replace with your server's IP address
    private const int serverPort = 5656;         // Replace with the server's port

    private Sprite receiveFileSprite;
    public GetImage getImage;

    private void Start()
    {
        StartClient();
    }

    private void StartClient()
    {
        TcpClient client = new TcpClient();
        client.Connect(serverHost, serverPort);
        Debug.Log("Connected to server");

        using (NetworkStream stream = client.GetStream())
        {
            using (FileStream fileStream = File.Create(Application.dataPath + "/Resources/received_file.png"))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fileStream.Write(buffer, 0, bytesRead);
                }
                print("123456");
            }
        }

        Debug.Log("File received successfully");

        HttpInfo info = new HttpInfo();
        string path = "File://" + Application.dataPath + "/Resources/received_file.png";

        info.Set(RequestType.TEXTURE, path, (DownloadHandler downloadHandler) =>
        {
            Texture2D tex =  ((DownloadHandlerTexture)downloadHandler).texture;
            receiveFileSprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
            getImage.ShowReceivedFile(receiveFileSprite);
            print("성공");
        }, false);

        HttpManager.Get().SendRequest(info);

        client.Close();
    }

    //public  Image downloadImage;
    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        HttpInfo info = new HttpInfo();
    //        string path = "File://" + Application.dataPath + "/Resources/received_file.png";

    //        info.Set(RequestType.TEXTURE, path, (DownloadHandler downloadHandler) =>
    //        {
    //            Texture2D tex = ((DownloadHandlerTexture)downloadHandler).texture;
    //            downloadImage.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
    //            print("성공");
    //        }, false);

    //        HttpManager.Get().SendRequest(info);
    //    }
    //}
}
