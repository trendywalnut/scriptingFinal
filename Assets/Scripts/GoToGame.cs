using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class GoToGame : MonoBehaviour
{
    [YarnCommand("Minigame")]
    public void GoToMiniGame()
    {
        SceneManager.LoadScene(8);
    }
}
