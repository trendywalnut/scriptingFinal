using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MiniGameController : MonoBehaviour
{
    private Transform tf;
    private Transform topTf, botTf;

    public TextMeshProUGUI percentText, timerText;

    public GameObject bottom, top;
    public GameObject winText, loseText;

    private bool gameStarted = false;

    public float jumpForce;
    public float gravity;
    public float minY;
    public float maxY;
    public float mixPercent;
    private float maxTime = 12;

    private void Start()
    {
        // Get transform for player block
        tf = GetComponent<Transform>();
        // Get transform for bottom and top of goal
        topTf = top.GetComponent<Transform>();
        botTf = bottom.GetComponent<Transform>();
    }

    private void Update()
    {
        //Minigame Start
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = true;
            loseText.SetActive(false);
        }

        if(gameStarted)
        {
            //Clamps player block Y
            if (tf.position.y > minY)
            {
                tf.Translate(Vector3.down * gravity);
            }

            //Jump code (also checks to make sure you're below maxY and that the game is still running)
            if (Input.GetKeyDown(KeyCode.Space) && tf.position.y < maxY && mixPercent < 100 && maxTime > 0)
            {
                tf.Translate(Vector3.up * jumpForce);
            }

            //Increases and displays mix percent when in the bounds of the goal
            if (tf.position.y > botTf.position.y && topTf.position.y > tf.position.y && mixPercent < 100)
            {
                mixPercent += .07f;
                percentText.text = "Mix Percent: " + (int)mixPercent + "%";
            }

            //Dispaly win text when you win, else keep ticking the clock down
            if (mixPercent > 99)
            {
                SceneManager.LoadScene(10);
                //winText.SetActive(true);
            }
            else if (maxTime >= 0)
            {
                maxTime -= Time.deltaTime;
                timerText.text = "Time Left: " + maxTime.ToString("F1");
            }

            //Display lose text, allow player to restart minigame, and resets values
            if (maxTime <= 0.001f)
            {
                SceneManager.LoadScene(9);
                //loseText.SetActive(true);
                gameStarted = false;
                maxTime = 12;
                mixPercent = 0;
            }
        }
        
    }
}
