using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System;
using UnityEngine.UI;

public class EventActive : MonoBehaviour
{
    public GameObject window;
    public GameObject enviroment;
    Animator anim;
    bool isActiveL = false;
    bool isActiveR = false;

    //bool isDetected = false;

    public GameObject Cursor;

    public Image Panel;
    float time = 0f;
    float fade_T = 0.1f;

    //[UnmanagedFunctionPointer(CallingConvention.StdCall)]
    //private delegate void DebugLog(string log);

    //private static readonly DebugLog debugLog = DebugWrapper;
    //private static readonly IntPtr functionPointer = Marshal.GetFunctionPointerForDelegate(debugLog);

    //private static void DebugWrapper(string log)
    //{
    //    Debug.Log(log);
    //}
    //[DllImport("opencv_practice")]
    //private static extern void LinkDebug([MarshalAs(UnmanagedType.FunctionPtr)] IntPtr debugCal);
    //[DllImport("opencv_practice")]
    //private static extern unsafe void RoiDetect(ref bool status);

    //public static void SetUpDebug()
    //{
    //    DebugLog debug;
    //    debug = DebugWrapper;
    //    IntPtr ptr = Marshal.GetFunctionPointerForDelegate(debug);
    //    LinkDebug(ptr);
    //}

    private void Start()
    {
        anim = GetComponent<Animator>();
        //SetUpDebug();
        //Task.Run(() => RoiDetect(ref isDetected));
    }

    private void Update()
    {
        //Debug.Log(GameManager.beforStart);
    }

    private void LateUpdate() // 카메라 애니메이션은 LateUpdate()에 만들어야해서 여기다 만들었어
    {
        SetEvent(); // 이게 카메라 이동 메인 함수

        if (GameManager.beforStart == true)
        {
            gameObject.transform.position = new Vector3(0, 60, -77);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            GameManager.beforStart = false;
            anim.speed = 1f;
            anim.Play("Start");
        }
    }

    void SetEvent()
    {
        accCursor acccursor = GameObject.Find("Cursor").GetComponent<accCursor>();
        if (acccursor.cursorState == 3 && acccursor.t == 90 && !isActiveL && !isActiveR && !GameManager.isFamily) // 가정 폭력은 1-2
        {
            anim.speed = 1f; 
            anim.Play("HouseEvent");
            GameManager.isEventFamily = true;
            FadeOUT();
            //Cursor.SetActive(false);
            Invoke("Hide", 0.45f); // 창문이 바로 사라지면 살짝 어색해서 딜레이 줬어 
        }

        if (Input.GetButtonDown("House Out") && isActiveL && isActiveR && !GameManager.isFamily) // 우클릭을 하면 돌아오는 애니메이션 구현 (예외 처리로 좌클릭을 누를경우 방지시켰는데 예외처리 한번 더 해야함. 그건 이벤트 구현 뒤에)
        {
            anim.speed = 1f;
            anim.Play("HouseEventOut");
            GameManager.isEventFamily = false;
            Invoke("Show", 0.11f);
        }

        if (acccursor.cursorState == 4 && acccursor.t == 90 && !isActiveL && !isActiveR && !GameManager.isEnviro) // 환경 문제는 3-4
        {
            anim.speed = 1f;
            anim.Play("EnviromentEvent");
            GameManager.isEventEnviro = true;
            FadeOUT();
            //Cursor.SetActive(false);
            Invoke("ShowE", 0.45f); 
        }

        if (Input.GetButtonDown("Enviroment Out") && isActiveL && isActiveR && !GameManager.isEnviro) 
        {
            anim.speed = 1f;
            anim.Play("EnviromentEventOut");
            GameManager.isEventEnviro = false;
            Invoke("HideE", 0.05f);
        }

        if (acccursor.cursorState == 2 && acccursor.t == 90 && !isActiveL && !isActiveR && !GameManager.isDate) // 데이트 폭력 문제는 5-6
        {
            anim.speed = 1f;
            anim.Play("DateEvent");
            GameManager.isEventDate = true;
            FadeOUT();
            //Cursor.SetActive(false);
            //Invoke("ShowE", 0.45f);
        }

        if (Input.GetButtonDown("Date Out") && isActiveL && isActiveR && !GameManager.isDate)
        {
            anim.speed = 1f;
            anim.Play("DateEventOut");
            GameManager.isEventDate = false;
            //Invoke("HideE", 0.05f);
        }

        if (acccursor.cursorState == 1 && acccursor.t == 90 && !isActiveL && !isActiveR && !GameManager.isSuicide) // 자살 문제는 7-8
        {
            anim.speed = 1f;
            anim.Play("SuicideEvent");
            GameManager.isEventSuicide = true;
            FadeOUT();
            //Cursor.SetActive(false);
            //Invoke("ShowE", 0.45f);
        }

        if (Input.GetButtonDown("Suicide Out") && isActiveL && isActiveR && !GameManager.isSuicide)
        {
            anim.speed = 1f;
            GameManager.isEventSuicide = false;
            anim.Play("SuicideEventOut");
            //Invoke("HideE", 0.05f);
        }

        if (acccursor.cursorState == 5 && acccursor.t == 90 && !isActiveL && !isActiveR && !GameManager.isAnimal) // 동물 유기 문제는 9-0
        {
            anim.speed = 1f;
            anim.Play("AnimalEvent");
            GameManager.isEventAnimal = true;
            FadeOUT();
            //Cursor.SetActive(false);
            //Invoke("ShowE", 0.45f);
        }

        if (Input.GetButtonDown("Animal Out") && isActiveL && isActiveR && !GameManager.isAnimal)
        {
            anim.speed = 1f;
            anim.Play("AnimalEventOut");
            GameManager.isEventAnimal = false;
            //Invoke("HideE", 0.05f);
        }
    }

    void Hide()
    {
        window.SetActive(false);
    }
    void Show()
    {
        window.SetActive(true);
    }
    void HideE()
    {
        enviroment.SetActive(false);
    }
    void ShowE()
    {
        enviroment.SetActive(true);
    }

    void Stop() // 이 함수는 애니메이션 특정 프레임에서 함수가 실행되게끔 만들었어 유니티 애니메이터 창에 설정 되어있어
    {
        anim.speed = 0f; // 애니메이션이 끝나면 맨 처음 위치로 돌아와서 그거 방지하려고 속도 0으로 해서 끝에 남아있게 만들었어
    }
    void IsActiveL()
    {
        isActiveL = true;
        Debug.Log(isActiveL);
    }
    void IsNotActiveL()
    {
        isActiveL = false;
        Debug.Log(isActiveL);
    }

    void IsActiveR()
    {
        isActiveR = true;
        Debug.Log(isActiveR);
    }
    void IsNotActiveR()
    {
        isActiveR = false;
        Debug.Log(isActiveR);
    }






    public void FadeIN()
    {
        StartCoroutine(FadeFlowIN()); // 꺼지는거
    }

    public void FadeOUT()
    {
        StartCoroutine(FadeFlowOUT());
    }

    IEnumerator FadeFlowIN()
    {
        time = 0f;
        Color alpha = Panel.color;

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fade_T;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        time = 0f;

        yield return null;
    }

    IEnumerator FadeFlowOUT()
    {
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fade_T;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }

        yield return null;
    }

}
