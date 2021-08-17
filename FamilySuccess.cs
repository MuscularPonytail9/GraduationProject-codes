using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System;


public class FamilySuccess : MonoBehaviour
{
    public GameObject Family_Success;
    bool isDetected = false;
    bool startActivity = false;
    AudioSource audioSource;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate void DebugLog(string log);

    private static readonly DebugLog debugLog = DebugWrapper;
    private static readonly IntPtr functionPointer = Marshal.GetFunctionPointerForDelegate(debugLog);

    private static void DebugWrapper(string log)
    {
        Debug.Log(log);
    }
    [DllImport("opencv_practice")]
    private static extern void LinkDebug([MarshalAs(UnmanagedType.FunctionPtr)] IntPtr debugCal);
    [DllImport("opencv_practice")]
    private static extern unsafe void RoiDetect(ref bool status);

    public static void SetUpDebug()
    {
        DebugLog debug;
        debug = DebugWrapper;
        IntPtr ptr = Marshal.GetFunctionPointerForDelegate(debug);
        LinkDebug(ptr);
    }

    private void Start()
    {
       // SetUpDebug();
        audioSource = GetComponent<AudioSource>();
       // Task.Run(() => RoiDetect(ref isDetected));
    }
    private void Update()
    {

        if ((isDetected == true && !startActivity) || (Input.GetKeyDown(KeyCode.Space) && !startActivity))
        {
            startActivity = true;
            audioSource.Play();
            Family_Success.SetActive(true);
            GameManager.isFamily = true;
            Invoke("MainScene", 5.7f);
        }
    }

    private void MainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
