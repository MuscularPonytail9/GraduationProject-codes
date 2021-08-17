using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneIn : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("MainScene In"))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
