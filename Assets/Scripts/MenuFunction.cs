using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuFunction : MonoBehaviour
{
    public GameObject gameManager;
    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quit test");
    }
}
