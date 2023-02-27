using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_menu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool StopIt = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {


            if (StopIt)
            {
                Resume();
            }

            else 
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        StopIt = false;
        AudioManager.Instance.UnPause("LevelMusic");
    }

    void Pause ()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        StopIt = true;
        AudioManager.Instance.Pause("LevelMusic");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        AudioManager.Instance.Stop("LevelMusic");
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("no");
        Application.Quit();

    }
   
       public void DoOver()
    {
        
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGM();
        }
        AudioManager.Instance.Stop("LevelMusic");

        SceneManager.LoadScene(1);
    }

}