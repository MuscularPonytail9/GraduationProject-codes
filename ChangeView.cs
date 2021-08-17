using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeView : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float fade_T = 2f;

    public GameObject star;
    public GameObject star2;
    public GameObject star3;

    public GameObject F_1;
    public GameObject F_2;
    public GameObject F_3;
    public GameObject F_4;
    public GameObject F_5;
    public GameObject F_6;
    public GameObject F_7;
    public GameObject F_8;
    public GameObject F_9;
    public GameObject F_10;
    public GameObject F_11;
    public GameObject F_H_1;
    public GameObject F_H_2;
    public GameObject F_H_3;
    public GameObject F_H_4;

    public GameObject D_1;
    public GameObject D_2;
    public GameObject D_3;
    public GameObject D_4;
    public GameObject D_5;
    public GameObject D_6;
    public GameObject D_7;
    public GameObject D_8;
    public GameObject F_D_1;
    public GameObject F_D_2;
    public GameObject F_D_3;
    public GameObject F_D_4;
    public GameObject F_D_5;
    public GameObject F_D_6;
    public GameObject F_D_7;

    public GameObject E_1;
    public GameObject E_2;
    public GameObject E_3;
    public GameObject E_4;
    public GameObject E_5;
    public GameObject F_E_1;
    public GameObject F_E_2;
    public GameObject F_E_3;
    public GameObject F_E_4;
    public GameObject F_E_5;

    public GameObject S_1;
    public GameObject S_2;
    public GameObject S_3;
    public GameObject S_4;
    public GameObject S_5;
    public GameObject S_6;
    public GameObject S_7;
    public GameObject F_S_1;
    public GameObject F_S_2;
    public GameObject F_S_3;
    public GameObject F_S_4;
    public GameObject F_S_5;
    public GameObject F_S_6;

    public GameObject A_1;
    public GameObject A_2;
    public GameObject A_3;
    public GameObject A_4;
    public GameObject A_5;
    public GameObject A_6;
    public GameObject A_7;
    public GameObject A_8;
    public GameObject A_9;
    public GameObject A_10;
    public GameObject A_11;
    public GameObject A_12;
    public GameObject A_13;
    public GameObject A_14;
    public GameObject A_15;
    public GameObject A_16;
    public GameObject A_17;
    public GameObject F_A_1;
    public GameObject F_A_2;
    public GameObject F_A_3;
    public GameObject F_A_4;
    public GameObject F_A_5;
    public GameObject F_A_6;
    public GameObject F_A_7;
    public GameObject F_A_8;
    public GameObject F_A_9;
    public GameObject F_A_10;
    public GameObject F_A_11;
    public GameObject F_A_12;
    public GameObject F_A_13;
    public GameObject F_A_14;
    public GameObject F_A_15;

    public GameObject AA_1;
    public GameObject AA_2;
    public GameObject AA_3;
    public GameObject AA_4;
    public GameObject AA_5;
    public GameObject AA_6;
    public GameObject AA_7;
    public GameObject AA_8;
    public GameObject AA_9;
    public GameObject AA_10;
    public GameObject AA_11;
    public GameObject AA_12;
    public GameObject AA_13;
    public GameObject AA_14;
    public GameObject AA_15;
    public GameObject AA_16;
    public GameObject F_AA_1;
    public GameObject F_AA_2;
    public GameObject F_AA_3;
    public GameObject F_AA_4;
    public GameObject F_AA_5;
    public GameObject F_AA_6;
    public GameObject F_AA_7;
    public GameObject F_AA_8;
    public GameObject F_AA_9;
    public GameObject F_AA_10;
    public GameObject F_AA_11;
    public GameObject F_AA_12;
    public GameObject F_AA_13;
    public GameObject F_AA_14;
    public GameObject F_AA_15;

    public GameObject FinishText;

    private void Start()
    {
        Panel.gameObject.SetActive(true);
        Invoke("Fade", 1f);
    }

    void Update()
    {
        if(GameManager.isEnviro == true)
        {
            E_1.SetActive(true);
            E_2.SetActive(true);
            E_3.SetActive(true);
            E_4.SetActive(true);
            E_5.SetActive(true);

            star.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
            F_E_1.SetActive(false);
            F_E_2.SetActive(false);
            F_E_3.SetActive(false);
            F_E_4.SetActive(false);
            F_E_5.SetActive(false);
        }

        if(GameManager.isDate == true)
        {
            D_1.SetActive(true);
            D_2.SetActive(true);
            D_3.SetActive(true);
            D_4.SetActive(true);
            D_5.SetActive(true);
            D_6.SetActive(true);
            D_7.SetActive(true);
            D_8.SetActive(true);

            F_D_1.SetActive(false);
            F_D_2.SetActive(false);
            F_D_3.SetActive(false);
            F_D_4.SetActive(false);
            F_D_5.SetActive(false);
            F_D_6.SetActive(false);
            F_D_7.SetActive(false);
        }

        if (GameManager.isFamily == true)
        {
            F_1.SetActive(true);
            F_2.SetActive(true);
            F_3.SetActive(true);
            F_4.SetActive(true);
            F_5.SetActive(true);
            F_6.SetActive(true);
            F_7.SetActive(true);
            F_8.SetActive(true);
            F_9.SetActive(true);
            F_10.SetActive(true);
            F_11.SetActive(true);
            AA_13.SetActive(true);

            F_H_1.SetActive(false);
            F_H_2.SetActive(false);
            F_H_3.SetActive(false);
            F_H_4.SetActive(false);
        }

        if(GameManager.isSuicide == true)
        {
            S_1.SetActive(true);
            S_2.SetActive(true);
            S_3.SetActive(true);
            S_4.SetActive(true);
            S_5.SetActive(true);
            S_6.SetActive(true);
            S_7.SetActive(true);

            F_S_1.SetActive(false);
            F_S_2.SetActive(false);
            F_S_3.SetActive(false);
            F_S_4.SetActive(false);
            F_S_5.SetActive(false);
            F_S_6.SetActive(false);
        }

        if(GameManager.isAnimal == true)
        {
            A_1.SetActive(true);
            A_2.SetActive(true);
            A_3.SetActive(true);
            A_4.SetActive(true);
            A_5.SetActive(true);
            A_6.SetActive(true);
            A_7.SetActive(true);
            A_8.SetActive(true);
            A_9.SetActive(true);
            A_10.SetActive(true);
            A_11.SetActive(true);
            A_12.SetActive(true);
            A_13.SetActive(true);
            A_14.SetActive(true);
            A_15.SetActive(true);
            A_16.SetActive(true);
            A_17.SetActive(true);

            F_A_1.SetActive(false);
            F_A_2.SetActive(false);
            F_A_3.SetActive(false);
            F_A_4.SetActive(false);
            F_A_5.SetActive(false);
            F_A_6.SetActive(false);
            F_A_7.SetActive(false);
            F_A_8.SetActive(false);
            F_A_9.SetActive(false);
            F_A_10.SetActive(false);
            F_A_11.SetActive(false);
            F_A_12.SetActive(false);
            F_A_13.SetActive(false);
            F_A_14.SetActive(false);
            F_A_15.SetActive(false);
        }

        if(GameManager.isAnimal && GameManager.isDate && GameManager.isFamily && GameManager.isSuicide && GameManager.isEnviro)
        {
            AA_1.SetActive(true);
            AA_2.SetActive(true);
            AA_3.SetActive(true);
            AA_4.SetActive(true);
            AA_5.SetActive(true);
            AA_6.SetActive(true);
            AA_7.SetActive(true);
            //AA_8.SetActive(true);
            AA_9.SetActive(true);
            AA_10.SetActive(true);
            AA_11.SetActive(true);
            AA_12.SetActive(true);
            
            AA_14.SetActive(true);
            AA_15.SetActive(true);
            AA_16.SetActive(true);

            F_AA_1.SetActive(false);
            F_AA_2.SetActive(false);
            F_AA_3.SetActive(false);
            F_AA_4.SetActive(false);
            F_AA_5.SetActive(false);
            F_AA_6.SetActive(false);
            F_AA_7.SetActive(false);
            F_AA_8.SetActive(false);
            F_AA_9.SetActive(false);
            F_AA_10.SetActive(false);
            F_AA_11.SetActive(false);
            F_AA_12.SetActive(false);
            F_AA_13.SetActive(false);
            F_AA_14.SetActive(false);
            F_AA_15.SetActive(false);

            FinishText.SetActive(true);
            //if (Input.GetKeyDown(KeyCode.B))
            //{
            //    FinalScene();
            //}
            if (Input.GetKeyDown(KeyCode.Z))
            {
                FinalScene();
            }
        }
    }

    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }

    void FinalScene()
    {
        SceneManager.LoadScene("FinalScene");
    }

    public void FadeIN()
    {
        StartCoroutine(FadeFlowIN());
    }

    IEnumerator FadeFlowIN()
    {
        Panel.gameObject.SetActive(true);
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

    IEnumerator FadeFlow()
    {
        time = 0f;
        Color alpha = Panel.color;

        yield return new WaitForSeconds(0f);

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
}
