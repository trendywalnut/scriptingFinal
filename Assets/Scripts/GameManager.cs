﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

    public class GameManager : MonoBehaviour
    {
        //Author: Carlos

        //add clips in the order MAIN MENU | FOREST | TOWER | LAKE OF FIRE (also rename to this from final boss music)
        public AudioClip[] clipsMusic;
        //can be added in any order, just make sure it lines up with the other scripts calling the public method
        // 0 + 1 footsteps, 2 menu select, 3 click select, 4 torch, 5 lava
        public AudioClip[] clipsSound;
        //add audio source to game manager prefab
        private AudioSource aS;

        void Awake()
        {
            if (FindObjectsOfType<GameManager>().Length > 1)
            {
                Destroy(this.gameObject);
            }
            else
            {
                DontDestroyOnLoad(this.gameObject);
            }
            aS = GetComponent<AudioSource>();
        }


        //not all scenes are in the index yet, so extra code will have to be added once the tower gets added to play the correct track
        void Update()
        {
            if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
            {
                if (aS.clip != clipsMusic[0] || !aS.isPlaying)
                {
                    aS.clip = clipsMusic[0];
                    aS.Play();
                }
            }
            if (SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4)
            {
                if (aS.clip != clipsMusic[1] || !aS.isPlaying)
                {
                    aS.clip = clipsMusic[1];
                    aS.Play();
                }
            }
            if (SceneManager.GetActiveScene().buildIndex == 5 || SceneManager.GetActiveScene().buildIndex == 6)
            {
                if (aS.clip != clipsMusic[2] || !aS.isPlaying)
                {
                    aS.clip = clipsMusic[2];
                    aS.Play();
                }
            }
            if (SceneManager.GetActiveScene().buildIndex == 7)
            {
                if (aS.clip != clipsMusic[3] || !aS.isPlaying)
                {
                    aS.clip = clipsMusic[3];
                    aS.Play();
                }
            }
        }

        //plays sound effect
        public void PlaySoundEffect(int index)
        {
            aS.PlayOneShot(clipsSound[index]);
        }
    }
