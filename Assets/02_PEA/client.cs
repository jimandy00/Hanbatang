using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.IO;

public class client : MonoBehaviour
{

    private const string serverHost = "192.168.1.24"; // Replace with your server's IP address
    private const int serverPort = 5656;         // Replace with the server's port

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
            using (FileStream fileStream = File.Create("received_file.png"))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fileStream.Write(buffer, 0, bytesRead);
                }
            }
        }

        Debug.Log("File received successfully");

        client.Close();
    }

}
