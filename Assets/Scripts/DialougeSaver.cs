using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeSaver : MonoBehaviour
{
    void Awake()
    {
        if (FindObjectsOfType<DialougeSaver>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
