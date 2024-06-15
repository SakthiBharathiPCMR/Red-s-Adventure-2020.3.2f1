using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;
    public void Home()
    {
        SceneManager.LoadScene("Start");
    }
    public void Restart()
    {
        SceneManager.LoadScene("GamePlay");
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    public void Play()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }




}
