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
    GET,        // 정보 요청
    POST,       // 정보 저장
    PUT,        // 정보 업데이트
    DELETE,     // 정보 삭제
    TEXTURE
}

// 웹 통신하기 위한 정보
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

    // HttpManager가 없을 경우 다시 생성해주는 함수
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
                // Get방식으로 req에 정보 세팅
                req = UnityWebRequest.Get(httpInfo.url);
                break;
            case RequestType.POST:
                req = UnityWebRequest.Post(httpInfo.url, httpInfo.body);
                byte[] byteBody = Encoding.UTF8.GetBytes(httpInfo.body);
                req.uploadHandler = new UploadHandlerRaw(byteBody);

                //헤더 추가
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

        // 서버에 요청을 보내고 응답이 올때까지 기다림
        yield return req.SendWebRequest();

        print("응답");

        // 만약 응답이 성공했으면 
        if (req.result == UnityWebRequest.Result.Success)
        {
            //print("네트워크 응답 : " + req.downloadHandler.text);

            if (httpInfo.onReceive != null)
            {
                httpInfo.onReceive(req.downloadHandler);
            }
        }

        // 통신 실패
        else
        {
            print("네트워크 에러 : " + req.error);
        }
    }
}
