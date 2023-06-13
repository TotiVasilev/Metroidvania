using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControlls : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
