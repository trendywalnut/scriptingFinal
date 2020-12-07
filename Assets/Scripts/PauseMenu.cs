using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Author: Henry
    private bool paused = false;
    public bool wMenu = true;

    [SerializeField]
    private GameObject menu;

    void OnSceneLoaded()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1)
        {
            wMenu = false;
        }
        else
        {
            wMenu = true;
        }
    }
    void Update()
    {
        if (wMenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (paused)
                {
                    paused = false;
                    menu.SetActive(false);
                    Time.timeScale = 1;
                }
                else
                {
                    paused = true;
                    Time.timeScale = 0;
                    menu.SetActive(true);
                }
            }
        }
    }
}
