using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool PauseMenu = false;
    public GameObject PauseMenuUi;
    public GameObject GameUi;
    public GameManager gamepauseManager;
    GameState pauseState;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (PauseMenu)
            {

                Resume();
            }
            else
            {
                Pause();


            }

            FindObjectOfType<SoundManager>().Play("MenuSelectAudio");



        }
    }
    public void Resume()
    {
        PauseMenuUi.SetActive(false);
        GameUi.SetActive(true);
        Time.timeScale = 1F;
        PauseMenu = false;
        gamepauseManager.gameState = pauseState;
        FindObjectOfType<SoundManager>().Play("MenuSelectAudio");
    }

    public void Pause()
    {


        pauseState = gamepauseManager.gameState;
        gamepauseManager.gameState = GameState.PAUSED;
        PauseMenuUi.SetActive(true);
        GameUi.SetActive(false);
        Time.timeScale = 0F;
        PauseMenu = true;
        FindObjectOfType<SoundManager>().Play("MenuSelectAudio");
    }

    public void QuitGame()
    {


        Debug.Log("Game Quit");
        Application.Quit();

        FindObjectOfType<SoundManager>().Play("MenuSelectAudio");

    }
    public void LoadMenu()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        FindObjectOfType<SoundManager>().Play("MenuSelectAudio");

    }

}