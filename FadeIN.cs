using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIN : MonoBehaviour
{
    public Image Panel;

    float time = 0f;
    float fade_T = 0.5f;

    bool isActiveL = false;
    bool isActiveR = false;

    public GameObject Cursor;

    void Start()
    {
        accCursor acccursor = GameObject.Find("Cursor").GetComponent<accCursor>();
    }

    void Update()
    {
        accCursor acccursor = GameObject.Find("Cursor").GetComponent<accCursor>();

        if (acccursor.cursorState == 3 && acccursor.t == 90  && !isActiveL && !isActiveR && !GameManager.isFamily)
        {
            Fade();
        }
        if (Input.GetButtonDown("House Out") && isActiveL && isActiveR && !GameManager.isFamily)
        {
            Fade();
        }
        if (acccursor.cursorState == 4 && acccursor.t == 90 && !isActiveL && !isActiveR && !GameManager.isEnviro)
        {
            Fade();
        }
        if (Input.GetButtonDown("Enviroment Out") && isActiveL && isActiveR && !GameManager.isEnviro)
        {
            Fade();
        }
        if (acccursor.cursorState == 2 && acccursor.t == 90 && !isActiveL && !isActiveR && !GameManager.isDate)
        {
            Fade();
        }
        if (Input.GetButtonDown("Date Out") && isActiveL && isActiveR && !GameManager.isDate)
        {
            Fade();
        }
        if (acccursor.cursorState == 1 && acccursor.t == 90 && !isActiveL && !isActiveR && !GameManager.isSuicide)
        {
            Fade();
        }
        if (Input.GetButtonDown("Suicide Out") && isActiveL && isActiveR && !GameManager.isSuicide)
        {
            Fade();
        }
        if (acccursor.cursorState == 5 && acccursor.t == 90 && !isActiveL && !isActiveR && !GameManager.isAnimal)
        {
            Fade();
        }
        if (Input.GetButtonDown("Animal Out") && isActiveL && isActiveR && !GameManager.isAnimal)
        {
            Fade();
        }
    }

    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }

    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;

        while(alpha.a < 1f)
        {
            time += Time.deltaTime / fade_T;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        time = 0f;

        // yield return new WaitForSeconds(0f);

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fade_T;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }

        Panel.gameObject.SetActive(false);
        yield return null;
    }

    void FIsActiveL()
    {
        isActiveL = true;
        Debug.Log(isActiveL);
    }
    void FIsNotActiveL()
    {
        isActiveL = false;
        Debug.Log(isActiveL);
    }

    void FIsActiveR()
    {
        isActiveR = true;
        Debug.Log(isActiveR);
    }
    void FIsNotActiveR()
    {
        isActiveR = false;
        Debug.Log(isActiveR);
    }
}
