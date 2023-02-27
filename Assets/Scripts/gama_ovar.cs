using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gama_ovar : MonoBehaviour
{
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "WinScreen")
        {
            AudioManager.Instance.Play("WinMusic");
        }
        else if (SceneManager.GetActiveScene().name == "LoseScreen")
        {
            AudioManager.Instance.Play("LoseMusic");
        }
        
    }
    
    public void RestartGame()
    {
        StopMusic();
        SceneManager.LoadScene(1);
    }

    public void MenuReturn()
    {
        StopMusic();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quitteded");
        Application.Quit();
    }

    public void StopMusic()
    {
        AudioManager.Instance.Stop("LoseMusic");
        AudioManager.Instance.Stop("WinMusic");
    }
}
