using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Events;
using UnityEngine.Android;

public class ClientSocket : MonoBehaviour
{
	#region private members 	
	private TcpClient socketConnection;
	private Thread clientReceiveThread;
	#endregion
	int t = 0;
	public string screenShotURL = "http://172.20.10.9//unity/uploader/mysavefile.php";
	UnityAction<string> OnErrorAction;
	UnityAction<string> OnCompleteAction;
	public GameObject btn;
	IEnumerator start()
	{
		yield return UploadPNG();
	}

	IEnumerator UploadPNG()
	{
		yield return new WaitForEndOfFrame();

		//int width = Screen.width;
		//int height = Screen.height;
		int width = 2224;
		int height = 1668;
		Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

		tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		tex.Apply();

		byte[] bytes = tex.EncodeToPNG();
		UnityEngine.Object.Destroy(tex);

		//System.IO.File.WriteAllBytes(Application.dataPath + "/screenShot.png", bytes);
		WWWForm form = new WWWForm();
		form.AddBinaryData("myimage", bytes, "screenShot.png", "image/png");

		WWW w = new WWW(screenShotURL, form);

		yield return w;

		if (w.error != null)
		{
			//error : 
			if (OnErrorAction != null)
				OnErrorAction(w.error); //or OnErrorAction.Invoke (w.error);
		}
		else
		{
			//success
			if (OnCompleteAction != null)
				OnCompleteAction(w.text); //or OnCompleteAction.Invoke (w.error);
		}
		w.Dispose();
	}
	void Start()
	{
		ConnectToTcpServer();
	}
	// Update is called once per frame
	void Update()
	{
		t++;
		if (t == 500)
		{
			
		}
	}
	/// <summary> 	
	/// Setup socket connection. 	
	/// </summary> 	
	private void ConnectToTcpServer()
	{
		try
		{
			clientReceiveThread = new Thread(new ThreadStart(ListenForData));
			clientReceiveThread.IsBackground = true;
			clientReceiveThread.Start();
		}
		catch (Exception e)
		{
			Debug.Log("On client connect exception " + e);
		}
	}
	/// <summary> 	
	/// Runs in background clientReceiveThread; Listens for incomming data. 	
	/// </summary>     
	private void ListenForData()
	{
		try
		{
			socketConnection = new TcpClient("192.168.0.10", 8052);
			Byte[] bytes = new Byte[1024];
			while (true)
			{
				// Get a stream object for reading 				
				using (NetworkStream stream = socketConnection.GetStream())
				{
					int length;
					// Read incomming stream into byte arrary. 					
					while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
					{
						var incommingData = new byte[length];
						Array.Copy(bytes, 0, incommingData, 0, length);
						// Convert byte array to string message. 						
						string serverMessage = Encoding.ASCII.GetString(incommingData);
						Debug.Log("server message received as: " + serverMessage);
					}
				}
			}
		}
		catch (SocketException socketException)
		{
			Debug.Log("Socket exception: " + socketException);
		}
	}
	private void SendMessage()
	{
		if (socketConnection == null)
		{
			return;
		}
		try
		{
			// Get a stream object for writing. 			
			NetworkStream stream = socketConnection.GetStream();
			if (stream.CanWrite)
			{
				string clientMessage = "0";
				// Convert string message to byte array.                 
				byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage);
				// Write byte array to socketConnection stream.                 
				stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
				Debug.Log("Client sent his message - should be received by server");
			}
		}
		catch (SocketException socketException)
		{
			Debug.Log("Socket exception: " + socketException);
		}
	}


	Texture2D GetTextureCopy(Texture2D source)
	{
		//Create a RenderTexture
		RenderTexture rt = RenderTexture.GetTemporary(
							   source.width,
							   source.height,
							   0,
							   RenderTextureFormat.Default,
							   RenderTextureReadWrite.Linear
						   );

		//Copy source texture to the new render (RenderTexture) 
		Graphics.Blit(source, rt);

		//Store the active RenderTexture & activate new created one (rt)
		RenderTexture previous = RenderTexture.active;
		RenderTexture.active = rt;

		//Create new Texture2D and fill its pixels from rt and apply changes.
		Texture2D readableTexture = new Texture2D(source.width, source.height);
		readableTexture.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
		readableTexture.Apply();

		//activate the (previous) RenderTexture and release texture created with (GetTemporary( ) ..)
		RenderTexture.active = previous;
		RenderTexture.ReleaseTemporary(rt);

		return readableTexture;
	}

	public void btnActive()
    {
		btn.SetActive(false);
		SendMessage();
		StartCoroutine("start");
	}
}