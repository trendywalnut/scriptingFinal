using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //private int health = 69;
    //private bool slickwitit = false;
    //public int integer;


    //add clips in the order MAIN MENU | FOREST | TOWER | LAKE OF FIRE (also rename to this from final boss music)
    public AudioClip[] clipsMusic;
    //can be added in any order, just make sure it lines up with the other scripts calling the public method
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
    }


    //not all scenes are in the index yet, so extra code will have to be added once the tower gets added to play the correct track
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (aS.clip != clipsMusic[0] || !aS.isPlaying)
            {
                aS.clip = clipsMusic[0];
                aS.Play();
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (aS.clip != clipsMusic[1] || !aS.isPlaying)
            {
                aS.clip = clipsMusic[1];
                aS.Play();
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (aS.clip != clipsMusic[3] || !aS.isPlaying)
            {
                aS.clip = clipsMusic[3];
                aS.Play();
            }
        }if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            if (aS.clip != clipsMusic[4] || !aS.isPlaying)
            {
                aS.clip = clipsMusic[4];
                aS.Play();
            }
        }
    }

    public void PlaySoundEffect(int index)
    {
        aS.PlayOneShot(clipsSound[index]);
    }
}