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
            else if (this.gameObject.tag == "ToSplit")
            {
                SceneManager.LoadScene(3);
            }
            else if (this.gameObject.tag == "ToLake")
            {
                SceneManager.LoadScene(4);
            }
            else if (this.gameObject.tag == "ToTowerOut")
            {
                SceneManager.LoadScene(5);
            }
            else if (this.gameObject.tag == "ToTowerIn")
            {
                SceneManager.LoadScene(6);
            }
        }
    }
}
