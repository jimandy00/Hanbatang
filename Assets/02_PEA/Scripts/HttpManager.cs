using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public struct SignUpInfo
{
    public string userName;
    public string birthday;
    public int age;
}

public enum RequestType
{
    GET,        // ���� ��û
    POST,       // ���� ����
    PUT,        // ���� ������Ʈ
    DELETE,     // ���� ����
    TEXTURE
}

// �� ����ϱ� ���� ����
public class HttpInfo
{
    public RequestType requestType;
    public string url = "";
    public string body;
    public Action<DownloadHandler> onReceive;

    public void Set(RequestType type, string u, Action<DownloadHandler> callback, bool useDefaultUrl = true)
    {
        requestType = type;
        if (useDefaultUrl) url = "http://192.168.1.97:5000";
        url += u;
        onReceive = callback;
    }
}

[Serializable]
public class JsonList<T>
{
    public List<T> data;
}

public class HttpManager : MonoBehaviour
{
    static HttpManager instance = null;

    // HttpManager�� ���� ��� �ٽ� �������ִ� �Լ�
    public static HttpManager Get()
    {
        if (instance == null)
        {
            GameObject obj = new GameObject("HttpManager");
            return obj.AddComponent<HttpManager>();
        }
        else
            return instance;
    }

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

    public void SendRequest(HttpInfo httpInfo)
    {
        StartCoroutine(CoSendRequest(httpInfo));
    }

    IEnumerator CoSendRequest(HttpInfo httpInfo)
    {
        UnityWebRequest req = null;

        switch (httpInfo.requestType)
        {
            case RequestType.GET:
                // Get������� req�� ���� ����
                req = UnityWebRequest.Get(httpInfo.url);
                break;
            case RequestType.POST:
                req = UnityWebRequest.Post(httpInfo.url, httpInfo.body);
                byte[] byteBody = Encoding.UTF8.GetBytes(httpInfo.body);
                req.uploadHandler = new UploadHandlerRaw(byteBody);

                //��� �߰�
                req.SetRequestHeader("Content-Type", "application/json");
                break;
            case RequestType.PUT:
                req = UnityWebRequest.Put(httpInfo.url, httpInfo.body);
                break;
            case RequestType.DELETE:
                req = UnityWebRequest.Delete(httpInfo.url);
                break;
            case RequestType.TEXTURE:
                req = UnityWebRequestTexture.GetTexture(httpInfo.url);
                print("Request");
                break;
        }

        // ������ ��û�� ������ ������ �ö����� ��ٸ�
        yield return req.SendWebRequest();

        print("����");

        // ���� ������ ���������� 
        if (req.result == UnityWebRequest.Result.Success)
        {
            //print("��Ʈ��ũ ���� : " + req.downloadHandler.text);

            if (httpInfo.onReceive != null)
            {
                httpInfo.onReceive(req.downloadHandler);
            }
        }

        // ��� ����
        else
        {
            print("��Ʈ��ũ ���� : " + req.error);
        }
    }
}
