using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        tf = GetComponent<Transform>();
        topTf = top.GetComponent<Transform>();
        botTf = bottom.GetComponent<Transform>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = true;
            loseText.SetActive(false);
        }

        if(gameStarted)
        {
            if (tf.position.y > minY)
            {
                tf.Translate(Vector3.down * gravity);
            }

            if (Input.GetKeyDown(KeyCode.Space) && tf.position.y < maxY && mixPercent < 100 && maxTime > 0)
            {
                tf.Translate(Vector3.up * jumpForce);
            }

            if (tf.position.y > botTf.position.y && topTf.position.y > tf.position.y && mixPercent < 100)
            {
                mixPercent += .07f;
                percentText.text = "Mix Percent: " + (int)mixPercent + "%";
            }

            if (mixPercent > 99)
            {
                winText.SetActive(true);
            }
            else if (maxTime >= 0)
            {
                maxTime -= Time.deltaTime;
                timerText.text = "Time Left: " + maxTime.ToString("F1");
            }

            if (maxTime <= 0.001f)
            {
                loseText.SetActive(true);
                gameStarted = false;
                maxTime = 12;
                mixPercent = 0;
            }
        }
        
    }
}
