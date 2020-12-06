using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuSaver : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("test");
        //finds pause menu canvas and saves it
        if (GameObject.FindGameObjectsWithTag("PauseMenu").Length > 1)
        {
            Debug.Log("destroy");
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("dont destroy");

            DontDestroyOnLoad(this.gameObject);
        }
    }
}
