﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void Start()
    {
        FindObjectOfType<SoundManager>().Play("Theme1");

    }
    public void PlayGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


       
    }


    public void QuitGame()

    {

        Debug.Log("Game Quit");
        Application.Quit();



    }


    public void PlaySelectAuio()

    {
        FindObjectOfType<SoundManager>().Play("MenuSelectAudio");

    }
}