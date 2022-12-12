using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameOver : MonoBehaviour
{

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
