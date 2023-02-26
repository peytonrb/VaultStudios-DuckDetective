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
    
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MenuReturn()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quitteded");
        Application.Quit();
    }
}
