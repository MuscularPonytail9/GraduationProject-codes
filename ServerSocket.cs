using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServerSocket : MonoBehaviour
{
	#region private members 	
	/// <summary> 	
	/// TCPListener to listen for incomming TCP connection 	
	/// requests. 	
	/// </summary> 	
	private TcpListener tcpListener;
	/// <summary> 
	/// Background thread for TcpServer workload. 	
	/// </summary> 	
	private Thread tcpListenerThread;
	/// <summary> 	
	/// Create handle to connected tcp client. 	
	/// </summary> 	
	private TcpClient connectedTcpClient;
	#endregion

	private string clientMessage;
	public GameObject success;
	public GameObject Success;
	private string serverIP = "172.20.10.9";
	AudioSource audioSource;
	bool isAudio = false;

	// Use this for initialization
	void Start()
	{
		// Start TcpServer background thread 		
		tcpListenerThread = new Thread(new ThreadStart(ListenForIncommingRequests));
		tcpListenerThread.IsBackground = true;
		tcpListenerThread.Start();

		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			SendMessage();
		}

		if((clientMessage == "0" && !isAudio) || (Input.GetKeyDown(KeyCode.Space) && !isAudio))
        {
			//success.SetActive(true);
			isAudio = true;
			Success.SetActive(true);
			GameManager.isEnviro = true;
			audioSource.Play();
			Invoke("MainScene", 5f);
        }

		
	}

	/// <summary> 	
	/// Runs in background TcpServerThread; Handles incomming TcpClient requests 	
	/// </summary> 	
	private void ListenForIncommingRequests()
	{
		try
		{
			// Create listener on localhost port 8052. 			
			tcpListener = new TcpListener(IPAddress.Parse(serverIP), 8052);
			tcpListener.Start();
			Debug.Log("Server is listening");
			Byte[] bytes = new Byte[1024];
			while (true)
			{
				using (connectedTcpClient = tcpListener.AcceptTcpClient())
				{
					// Get a stream object for reading 					
					using (NetworkStream stream = connectedTcpClient.GetStream())
					{
						int length;
						// Read incomming stream into byte arrary. 						
						while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
						{
							var incommingData = new byte[length];
							Array.Copy(bytes, 0, incommingData, 0, length);
							// Convert byte array to string message. 							
							clientMessage = Encoding.ASCII.GetString(incommingData);
							Debug.Log("client message received as: " + clientMessage);
						}
					}
				}
			}
		}
		catch (SocketException socketException)
		{
			Debug.Log("SocketException " + socketException.ToString());
		}
	}
	/// <summary> 	
	/// Send message to client using socket connection. 	
	/// </summary> 	
	private void SendMessage()
	{
		if (connectedTcpClient == null)
		{
			return;
		}

		try
		{
			// Get a stream object for writing. 			
			NetworkStream stream = connectedTcpClient.GetStream();
			if (stream.CanWrite)
			{
				string serverMessage = "This is a message from your server.";
				// Convert string message to byte array.                 
				byte[] serverMessageAsByteArray = Encoding.ASCII.GetBytes(serverMessage);
				// Write byte array to socketConnection stream.               
				stream.Write(serverMessageAsByteArray, 0, serverMessageAsByteArray.Length);
				Debug.Log("Server sent his message - should be received by client");
			}
		}
		catch (SocketException socketException)
		{
			Debug.Log("Socket exception: " + socketException);
		}
	}

	private void MainScene()
    {
		SceneManager.LoadScene("MainScene");
	}
}