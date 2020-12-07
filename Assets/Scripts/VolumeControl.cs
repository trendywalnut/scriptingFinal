using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    //Author: Connor

    //set up audio source and a float for the volume slider 
    private AudioSource audioSrc;

    private float musicVolume = 1f;

    private void Start()
    {
        //find audio source
        audioSrc = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //sets volume equal to float
        audioSrc.volume = musicVolume;
    }

    public void SetVolume(float sliderValue)
    {
        //passes slider value to the float in order to change the volume
        musicVolume = sliderValue;
    }
}
