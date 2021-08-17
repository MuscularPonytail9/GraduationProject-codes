using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class Capture : MonoBehaviour
{
    string m_Path = @"/Users/whalsrnwkd/Desktop/image/"; // 이 경로가 사진 하나가지고 쓸 거
    string m_Path_Real = @"/Users/whalsrnwkd/img_silde_web/src/assets/images/"; // 이 경로가 나중에 사진 달라고 할 때 줄 거 
    // 폴더는 윈도우 에서 따로 만들고 지정해줘야 할거야.
    string m_FilePrefix = "Graduation_";
    private string m_FilePath;
    private string m_FilePath_Real;

    public Renderer display;
    WebCamTexture camTexture;
    private int currentIndex = 0;


    private void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        if (camTexture != null)
        {
            display.material.mainTexture = null;
            camTexture.Stop();
            camTexture = null;
        }
        WebCamDevice device = WebCamTexture.devices[currentIndex];
        camTexture = new WebCamTexture(device.name);
        display.material.mainTexture = camTexture;
        camTexture.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_FilePath_Real = m_Path + m_FilePrefix + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg"; // 이게 연도별로 계속 축적
            m_FilePath = m_Path_Real + m_FilePrefix + ".jpg"; // 이게 사진 한장으로 돌려쓸거

            bool result = File.Exists(m_FilePath);

            if (result)
            {
                Debug.Log("File Found");
                File.Delete(m_FilePath);
                Debug.Log("File Deleted Successfully");
            }

            StartCoroutine(SaveScreeJpg(m_FilePath));
            StartCoroutine(SaveScreeJpg(m_FilePath_Real));
            camTexture.Stop();
            camTexture = null;
        }
    }

    IEnumerator SaveScreeJpg(string filePath)
    {
        yield return new WaitForEndOfFrame();

        Texture2D texture = new Texture2D(Screen.width, Screen.height);
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();
        byte[] bytes = texture.EncodeToJPG();
        File.WriteAllBytes(filePath, bytes);
        Debug.Log("Capture ScreenShot");
        DestroyImmediate(texture);
    }
}
