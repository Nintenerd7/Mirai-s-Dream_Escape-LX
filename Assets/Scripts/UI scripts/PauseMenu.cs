using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool IsPaused;
    [SerializeField] GameObject pauseMenu;
    public GameObject[] hide_obj = new GameObject [2];

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                resume();
                hide_obj[0].SetActive(true);
                hide_obj[1].SetActive(true);
            }
            else
            {
                Paused();
                hide_obj[0].SetActive(false);
                hide_obj[1].SetActive(false);
            }
        }
    }
    public void Paused()
    {
        IsPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;//pauses menu
    }


    public void resume()
    {
    hide_obj[0].SetActive(true);
    hide_obj[1].SetActive(true);
       IsPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;//menu disapears
    }

    public void Menu()
    {
        AudioSourceController.Instance.PlayMusic("Title");
        IsPaused = false;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(0);//loads title screen
        Time.timeScale = 1f;//menu disapears
        //Collectible.Count = 0;
    }
}