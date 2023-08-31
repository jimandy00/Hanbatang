using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPReceive : MonoBehaviour
{
    Thread receiveThread;
    UdpClient client; 
    public int port = 5052;
    public bool startRecieving = true;
    public bool printToConsole = false;
    public string data;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // 스크립트가 시행되고 제일 처음 시행되는 함수
    public void Start()
    {
        // 쓰레드 생성
        receiveThread = new Thread(
            new ThreadStart(ReceiveData)); 
        // 백그라운드에서 실행
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    // UdpClient 인스턴스 생성 함수
    private void ReceiveData()
    {

        // 특정 포트번호로 UdpClinet 생성
        client = new UdpClient(port);
        while (startRecieving)
        {
            try
            {
                // 어떤 ip이든 수신
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                // 바이트어레이형태로 데이터 수신
                byte[] dataByte = client.Receive(ref anyIP); // 수신하는 데이터의 타입
                // UTF8인코딩
                data = Encoding.UTF8.GetString(dataByte);
                if (printToConsole) { print(data); }

                Do.instance.GetData(data);
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }
}
