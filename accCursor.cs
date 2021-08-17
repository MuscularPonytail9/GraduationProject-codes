using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.UI;

public class accCursor : MonoBehaviour
{
    public RectTransform transform_cursor;
    public Vector2 CursorPos;
    SerialPort m_SerialPort = new SerialPort("COM3", 4800, Parity.None, 8, StopBits.One);
    string m_data = null;
    public int cursorState;
    public int t = 0;
    private void Start()
    {
        
        m_SerialPort.Open();
        Init_Cursor();
        cursorState = 0;
    }

    private void Update()
    {
        Update_MousePosition();
        cursorPosCheck();
    }
    private void OnApplicationQuit()
    {
        m_SerialPort.Close();
    }
    private void Init_Cursor()
    {
        transform_cursor.pivot = Vector2.up;

        if (transform_cursor.GetComponent<Graphic>())
        {
            transform_cursor.GetComponent<Graphic>().raycastTarget = false;
        }
    }
    private void Update_MousePosition()
    {
        
        m_data = m_SerialPort.ReadLine();
        
        string[] position = m_data.Split((' '));
        float[] pos = new float[2];
        for (int i = 0; i < position.Length; i++)
        {
            pos[i] = float.Parse(position[i]);
        }
        CursorPos.Set(500 - 1500 * pos[1], 500 - 1500 * pos[0]);
        transform_cursor.position = CursorPos;
        Debug.Log(CursorPos);
    }
    private void cursorPosCheck()
    {
        if (155 > CursorPos[0] && CursorPos[0] > -45 && 1055 > CursorPos[1] && CursorPos[1] > 855) //ㅈㅅ
        {
            cursorState = 1;
            t++;
        }
        else if (815 > CursorPos[0] && CursorPos[0] > 615 && 995 > CursorPos[1] && CursorPos[1] > 795) // ㄷㅇㅌ 475 595
        {
            cursorState = 2;
            t++;
        }
        else if (470 > CursorPos[0] && CursorPos[0] > 270 && 410 > CursorPos[1] && CursorPos[1] > 210) // ㅇㄱㄱ 5로 바꿔야함
        {
            cursorState = 5;
            t++;
        }
        else if (155 > CursorPos[0] && CursorPos[0] > -45 && 650 > CursorPos[1] && CursorPos[1] > 400) // ㅎㄱ
        {
            cursorState = 4;
            t++;
        }
        else if (905 > CursorPos[0] && CursorPos[0] > 705 && 785 > CursorPos[1] && CursorPos[1] > 584) // ㄱㅈㅍㄹ
        {
            cursorState = 3;
            t++;
        }
        else
        {
            t = 0;
        }
    }
}
