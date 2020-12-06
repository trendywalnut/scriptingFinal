using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    private AudioSource audioSrc;

    private float musicVolume = 1f;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    private void Update()
    {
        audioSrc.volume = musicVolume;
    }

    public void SetVolume(float sliderValue)
    {
        musicVolume = sliderValue;
    }
}
