using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActive : MonoBehaviour
{
    public GameObject btn_E;
    public GameObject btn_F;
    public GameObject btn_D;
    public GameObject btn_S;
    public GameObject btn_A;

    public void HideBtn_E()
    {
        btn_E.SetActive(false);

        btn_F.SetActive(false);

        btn_D.SetActive(false);

        btn_S.SetActive(false);

        btn_A.SetActive(false);
    }

    public void AppendBtn_E()
    {
        btn_E.SetActive(true);

        btn_F.SetActive(false);

        btn_D.SetActive(false);

        btn_S.SetActive(false);

        btn_A.SetActive(false);
    }

    public void HideBtn_F()
    {
        btn_F.SetActive(false);

        btn_E.SetActive(false);

        btn_D.SetActive(false);

        btn_S.SetActive(false);

        btn_A.SetActive(false);
    }

    public void AppendBtn_F()
    {
        btn_F.SetActive(true);

        btn_E.SetActive(false);

        btn_D.SetActive(false);

        btn_S.SetActive(false);

        btn_A.SetActive(false);
    }

    public void HideBtn_D()
    {
        btn_F.SetActive(false);

        btn_E.SetActive(false);

        btn_D.SetActive(false);

        btn_S.SetActive(false);

        btn_A.SetActive(false);
    }

    public void AppendBtn_D()
    {
        btn_F.SetActive(false);

        btn_E.SetActive(false);

        btn_D.SetActive(true);

        btn_S.SetActive(false);

        btn_A.SetActive(false);
    }

    public void HideBtn_S()
    {
        btn_F.SetActive(false);

        btn_E.SetActive(false);

        btn_D.SetActive(false);

        btn_S.SetActive(false);

        btn_A.SetActive(false);
    }

    public void AppendBtn_S()
    {
        btn_F.SetActive(false);

        btn_E.SetActive(false);

        btn_D.SetActive(false);

        btn_S.SetActive(true);

        btn_A.SetActive(false);
    }

    public void HideBtn_A()
    {
        btn_F.SetActive(false);

        btn_E.SetActive(false);

        btn_D.SetActive(false);

        btn_S.SetActive(false);

        btn_A.SetActive(false);
    }

    public void AppendBtn_A()
    {
        btn_F.SetActive(false);

        btn_E.SetActive(false);

        btn_D.SetActive(false);

        btn_S.SetActive(false);

        btn_A.SetActive(true);
    }

    public void OnClick_Btn_F()
    {
        SceneManager.LoadScene("Family_Event");
    }

    public void OnClick_Btn_E()
    {
        SceneManager.LoadScene("Enviroment_Event");
    }

    public void OnClick_Btn_D()
    {
        SceneManager.LoadScene("Date_Event");
    }

    public void OnClick_Btn_S()
    {
        SceneManager.LoadScene("Suicide_Event");
    }

    public void OnClick_Btn_A()
    {
        SceneManager.LoadScene("Animal_Event");
    }
}
