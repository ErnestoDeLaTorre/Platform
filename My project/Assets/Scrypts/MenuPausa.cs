using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject pausaButton;
    public GameObject pausaMenu;
    public void Pausa()
    {
        Time.timeScale = 0f;
        pausaButton.SetActive(false);
        pausaMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pausaButton.SetActive(true);
        pausaMenu.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Exit()
    {
        Debug.Log("Closing Game");
        Application.Quit();
    }
}
