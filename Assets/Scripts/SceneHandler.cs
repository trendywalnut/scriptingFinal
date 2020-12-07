using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{
    //Author: Henry

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
            if (this.gameObject.tag == "ToPath")
            {
                goToScene = 3;
                levelDisplay.text = "Press \"Space\" to go to Path ";
            }
            else if (this.gameObject.tag == "ToWitch")
            {
                goToScene = 2;
                levelDisplay.text = "Press \"Space\" to go to the Witch's Hut ";
            }
            else if (this.gameObject.tag == "ToSplit")
            {
                goToScene = 4;
                levelDisplay.text = "Press \"Space\" to go to the Crossroads ";
            }
            else if (this.gameObject.tag == "ToLake")
            {
                goToScene = 7;
                levelDisplay.text = "Press \"Space\" to go to The Lake of Fire ";
            }
            else if (this.gameObject.tag == "ToTowerOut")
            {
                goToScene = 5;
                levelDisplay.text = "Press \"Space\" to go to The Crystal Tower ";
            }
            else if (this.gameObject.tag == "ToTowerIn")
            {
                goToScene = 6;
                levelDisplay.text = "Press \"Space\" to go to in to the Crystal Tower ";
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        levelDisplay.text = "";
    }
}
