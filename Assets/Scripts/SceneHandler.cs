using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{
    private bool inTrigger;
    private int goToScene;
    public Text levelDisplay;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inTrigger == true)
        {
            SceneManager.LoadScene(goToScene);            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log(other.tag);
        if (other.gameObject.tag == "Player") //checks if the player is in a trigger and if they are lpaying the interact button. 
        {
            inTrigger = true;
            Debug.Log(inTrigger);
            if (this.gameObject.tag == "ToPath")
            {
                goToScene = 2;
                levelDisplay.text = "Press \"Space\" to go to Path ";
                Debug.Log(goToScene);
            }
            else if (this.gameObject.tag == "ToWitch")
            {
                goToScene = 1;
                levelDisplay.text = "Press \"Space\" to go to the Witch's Hut ";
                Debug.Log(goToScene);
            }
            else if (this.gameObject.tag == "ToSplit")
            {
                goToScene = 3;
                levelDisplay.text = "Press \"Space\" to go to the Crossroads ";
                Debug.Log(goToScene);
            }
            else if (this.gameObject.tag == "ToLake")
            {
                goToScene = 6;
                levelDisplay.text = "Press \"Space\" to go to The Lake of Fire ";
                Debug.Log(goToScene);
            }
            else if (this.gameObject.tag == "ToTowerOut")
            {
                goToScene = 4;
                levelDisplay.text = "Press \"Space\" to go to The Crystal Tower ";
                Debug.Log(goToScene);
            }
            else if (this.gameObject.tag == "ToTowerIn")
            {
                goToScene = 5;
                levelDisplay.text = "Press \"Space\" to go to in to the Crystal Tower ";
                Debug.Log(goToScene);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        levelDisplay.text = "";
        Debug.Log(inTrigger);
    }
}
