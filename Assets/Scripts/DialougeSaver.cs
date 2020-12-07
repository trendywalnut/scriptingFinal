using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeSaver : MonoBehaviour
{
    void Awake()
    {
        //finds dialogue and saves it in between scenes
        if (FindObjectsOfType<DialougeSaver>().Length > 1)
        {
            //if there is more than one
            Destroy(this.gameObject);
        }
        else
        {
            //dont destroy if only one
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
