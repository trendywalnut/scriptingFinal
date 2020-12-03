using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool paused = true;
    public bool wMenu = true;

    [SerializeField]
    private GameObject board;

    [SerializeField]
    private GameObject menu;

    void Update()
    {
        if (wMenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (paused)
                {
                    Time.timeScale = 1;
                    menu.SetActive(false);
                }
                else
                {
                    Time.timeScale = 0;
                    menu.SetActive(true);
                }
            }
        }
        else
        {
            board.SetActive(true);
        }
    }
}
