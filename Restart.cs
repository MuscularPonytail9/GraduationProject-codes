using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.L))
        {
            GameManager.isAnimal = false;
            GameManager.isEventAnimal = false;

            GameManager.isDate = false;
            GameManager.isEventDate = false;

            GameManager.isFamily = false;
            GameManager.isEventFamily = false;

            GameManager.isEnviro = false;
            GameManager.isEventEnviro = false;

            GameManager.isSuicide = false;
            GameManager.isEventSuicide = false;

            GameManager.beforStart = true;

            SceneManager.LoadScene("MainScene");
        }
    }
}
