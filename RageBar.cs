using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO.Ports;


public class RageBar : MonoBehaviour
{
    //SerialPort m_SerialPort = new SerialPort("COM4", 4800, Parity.None, 8, StopBits.One);
    //string m_data = null;
    public Image one;
    public Image two;
    public Image three;
    public Image four;
    public Image five;
    public Image six;
    public Image seven;
    public Image eight;
    public Image nine;
    public Image ten;
    public Image eleven;// 이거는 게이지 블록들

    public GameObject Anger1;
    public GameObject Anger2;
    public GameObject Anger3; // 이거는 여자친구 화남 표시등

    public GameObject AngerM1;
    public GameObject AngerM2;
    public GameObject AngerM3;

    public GameObject Bar;
    public GameObject Rage_Bar;
    public GameObject Text_R;
    public GameObject Text_M;

    public GameObject SuccessAnim;
    bool isSuccess = false;

    int gage; // 압력 센서 값을 여기에다가 넣으면 돼!

    AudioSource audioSource;
    bool isAudio = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //m_SerialPort.Open();
    }
    private void OnApplicationQuit()
    {
        //m_SerialPort.Close();
    }
    private void Update()
    {
        //m_data = m_SerialPort.ReadLine();
        // gage = int.Parse(m_data);
        gage = 1300;
        if (gage < 0)
        {
            gage = 0; // 그리고 게이지가 0이면 그대로 계속 0으로 만들었움.
        }
        if((gage > 1100 && !isAudio) || (Input.GetKeyDown(KeyCode.Space) && !isAudio))
        {
            isAudio = true;
            GameManager.isDate = true;
            isSuccess = true;
            SuccessAnim.SetActive(true);

            one.gameObject.SetActive(false);
            two.gameObject.SetActive(false);
            three.gameObject.SetActive(false);
            four.gameObject.SetActive(false);
            five.gameObject.SetActive(false);
            six.gameObject.SetActive(false);
            seven.gameObject.SetActive(false);
            eight.gameObject.SetActive(false);
            nine.gameObject.SetActive(false);
            ten.gameObject.SetActive(false);
            eleven.gameObject.SetActive(false);

            Anger1.SetActive(false);
            Anger2.SetActive(false);
            Anger3.SetActive(false);

            AngerM1.SetActive(false);
            AngerM2.SetActive(false);
            AngerM3.SetActive(false);

            Bar.SetActive(false);
            Rage_Bar.SetActive(false);
            Text_M.SetActive(false);
            Text_R.SetActive(false);

            audioSource.Play();
            Invoke("MainScene", 8f); // 게이지가 도달하면 메인씬으로 이동하는건데 나중에 수정해야지
        }

        ActiveBar(); // 이건 압력센서 값에따라 블록이 올라갔다 내려가는거 구현했어 + 여자친구 화남 표시등까지
    }

    void ActiveBar()
    {
        if(gage < 100 && gage > 0 && !isSuccess)
        {
            one.gameObject.SetActive(true);
            two.gameObject.SetActive(false);
            three.gameObject.SetActive(false);
            four.gameObject.SetActive(false);
            five.gameObject.SetActive(false);
            six.gameObject.SetActive(false);
            seven.gameObject.SetActive(false);
            eight.gameObject.SetActive(false);
            nine.gameObject.SetActive(false);
            ten.gameObject.SetActive(false);
            eleven.gameObject.SetActive(false);

            Anger1.SetActive(false);
            Anger2.SetActive(false);
            Anger3.SetActive(false);

            AngerM1.SetActive(false);
            AngerM2.SetActive(false);
            AngerM3.SetActive(false);
        }
        else if(gage < 200 && gage > 100 && !isSuccess)
        {
            one.gameObject.SetActive(true);
            two.gameObject.SetActive(true);
            three.gameObject.SetActive(false);
            four.gameObject.SetActive(false);
            five.gameObject.SetActive(false);
            six.gameObject.SetActive(false);
            seven.gameObject.SetActive(false);
            eight.gameObject.SetActive(false);
            nine.gameObject.SetActive(false);
            ten.gameObject.SetActive(false);
            eleven.gameObject.SetActive(false);

            Anger1.SetActive(false);
            Anger2.SetActive(false);
            Anger3.SetActive(false);

            AngerM1.SetActive(false);
            AngerM2.SetActive(false);
            AngerM3.SetActive(false);
        }
        else if (gage < 300 && gage > 200 && !isSuccess)
        {
            one.gameObject.SetActive(true);
            two.gameObject.SetActive(true);
            three.gameObject.SetActive(true);
            four.gameObject.SetActive(false);
            five.gameObject.SetActive(false);
            six.gameObject.SetActive(false);
            seven.gameObject.SetActive(false);
            eight.gameObject.SetActive(false);
            nine.gameObject.SetActive(false);
            ten.gameObject.SetActive(false);
            eleven.gameObject.SetActive(false);

            Anger1.SetActive(true);
            Anger2.SetActive(false);
            Anger3.SetActive(false);

            AngerM1.SetActive(true);
            AngerM2.SetActive(false);
            AngerM3.SetActive(false);
        }
        else if (gage < 400 && gage > 300 && !isSuccess)
        {
            one.gameObject.SetActive(true);
            two.gameObject.SetActive(true);
            three.gameObject.SetActive(true);
            four.gameObject.SetActive(true);
            five.gameObject.SetActive(false);
            six.gameObject.SetActive(false);
            seven.gameObject.SetActive(false);
            eight.gameObject.SetActive(false);
            nine.gameObject.SetActive(false);
            ten.gameObject.SetActive(false);
            eleven.gameObject.SetActive(false);

            Anger1.SetActive(true);
            Anger2.SetActive(false);
            Anger3.SetActive(false);

            AngerM1.SetActive(true);
            AngerM2.SetActive(false);
            AngerM3.SetActive(false);
        }
        else if (gage < 500 && gage > 400 && !isSuccess)
        {
            one.gameObject.SetActive(true);
            two.gameObject.SetActive(true);
            three.gameObject.SetActive(true);
            four.gameObject.SetActive(true);
            five.gameObject.SetActive(true);
            six.gameObject.SetActive(false);
            seven.gameObject.SetActive(false);
            eight.gameObject.SetActive(false);
            nine.gameObject.SetActive(false);
            ten.gameObject.SetActive(false);
            eleven.gameObject.SetActive(false);

            Anger1.SetActive(true);
            Anger2.SetActive(false);
            Anger3.SetActive(false);

            AngerM1.SetActive(true);
            AngerM2.SetActive(false);
            AngerM3.SetActive(false);
        }
        else if (gage < 600 && gage > 500 && !isSuccess)
        {
            one.gameObject.SetActive(true);
            two.gameObject.SetActive(true);
            three.gameObject.SetActive(true);
            four.gameObject.SetActive(true);
            five.gameObject.SetActive(true);
            six.gameObject.SetActive(true);
            seven.gameObject.SetActive(false);
            eight.gameObject.SetActive(false);
            nine.gameObject.SetActive(false);
            ten.gameObject.SetActive(false);
            eleven.gameObject.SetActive(false);

            Anger1.SetActive(false);
            Anger2.SetActive(true);
            Anger3.SetActive(false);

            AngerM1.SetActive(false);
            AngerM2.SetActive(true);
            AngerM3.SetActive(false);
        }
        else if (gage < 700 && gage > 600 && !isSuccess)
        {
            one.gameObject.SetActive(true);
            two.gameObject.SetActive(true);
            three.gameObject.SetActive(true);
            four.gameObject.SetActive(true);
            five.gameObject.SetActive(true);
            six.gameObject.SetActive(true);
            seven.gameObject.SetActive(true);
            eight.gameObject.SetActive(false);
            nine.gameObject.SetActive(false);
            ten.gameObject.SetActive(false);
            eleven.gameObject.SetActive(false);

            Anger1.SetActive(false);
            Anger2.SetActive(true);
            Anger3.SetActive(false);

            AngerM1.SetActive(false);
            AngerM2.SetActive(true);
            AngerM3.SetActive(false);
        }
        else if (gage < 800 && gage > 700 && !isSuccess)
        {
            one.gameObject.SetActive(true);
            two.gameObject.SetActive(true);
            three.gameObject.SetActive(true);
            four.gameObject.SetActive(true);
            five.gameObject.SetActive(true);
            six.gameObject.SetActive(true);
            seven.gameObject.SetActive(true);
            eight.gameObject.SetActive(true);
            nine.gameObject.SetActive(false);
            ten.gameObject.SetActive(false);
            eleven.gameObject.SetActive(false);

            Anger1.SetActive(false);
            Anger2.SetActive(true);
            Anger3.SetActive(false);

            AngerM1.SetActive(false);
            AngerM2.SetActive(true);
            AngerM3.SetActive(false);
        }
        else if (gage < 900 && gage > 800 && !isSuccess)
        {
            one.gameObject.SetActive(true);
            two.gameObject.SetActive(true);
            three.gameObject.SetActive(true);
            four.gameObject.SetActive(true);
            five.gameObject.SetActive(true);
            six.gameObject.SetActive(true);
            seven.gameObject.SetActive(true);
            eight.gameObject.SetActive(true);
            nine.gameObject.SetActive(true);
            ten.gameObject.SetActive(false);
            eleven.gameObject.SetActive(false);

            Anger1.SetActive(false);
            Anger2.SetActive(false);
            Anger3.SetActive(true);

            AngerM1.SetActive(false);
            AngerM2.SetActive(false);
            AngerM3.SetActive(true);
        }
        else if(gage < 1000 && gage > 900 && !isSuccess)
        {
            one.gameObject.SetActive(true);
            two.gameObject.SetActive(true);
            three.gameObject.SetActive(true);
            four.gameObject.SetActive(true);
            five.gameObject.SetActive(true);
            six.gameObject.SetActive(true);
            seven.gameObject.SetActive(true);
            eight.gameObject.SetActive(true);
            nine.gameObject.SetActive(true);
            ten.gameObject.SetActive(true);
            eleven.gameObject.SetActive(false);

            Anger1.SetActive(false);
            Anger2.SetActive(false);
            Anger3.SetActive(true);

            AngerM1.SetActive(false);
            AngerM2.SetActive(false);
            AngerM3.SetActive(true);
        }
        else if (gage > 1000 && !isSuccess)
        {
            one.gameObject.SetActive(true);
            two.gameObject.SetActive(true);
            three.gameObject.SetActive(true);
            four.gameObject.SetActive(true);
            five.gameObject.SetActive(true);
            six.gameObject.SetActive(true);
            seven.gameObject.SetActive(true);
            eight.gameObject.SetActive(true);
            nine.gameObject.SetActive(true);
            ten.gameObject.SetActive(true);
            eleven.gameObject.SetActive(true);

            Anger1.SetActive(false);
            Anger2.SetActive(false);
            Anger3.SetActive(true);

            AngerM1.SetActive(false);
            AngerM2.SetActive(false);
            AngerM3.SetActive(true);
        }
    }

    private void MainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
