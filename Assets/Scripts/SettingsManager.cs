using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SettingsManager : MonoBehaviour
{
    //Author: Connor

    public Slider volumeSlider;

    //set up string to remember the settings
    private const string Music_Volume_Pref = "music-volume";

    void Start()
    {
        //find player pref
        volumeSlider.value = PlayerPrefs.GetFloat(Music_Volume_Pref, 1);
    }

    //set pref
    private void SetPref(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    //set volume
    public void onChangeMusicVolume(Single value)
    {
        SetPref(Music_Volume_Pref, value);
    }
}
