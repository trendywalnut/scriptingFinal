using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("player detect");
            if (this.gameObject.tag == "ToPath")
            {
                SceneManager.LoadScene(2);
                Debug.Log("it is soemthing");
            }
            else if (this.gameObject.tag == "ToWitch")
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
