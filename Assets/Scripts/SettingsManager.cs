using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;

    private const string Music_Volume_Pref = "music-volume";

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat(Music_Volume_Pref, 1);
    }


    private void SetPref(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public void onChangeMusicVolume(Single value)
    {
        SetPref(Music_Volume_Pref, value);
    }
}
