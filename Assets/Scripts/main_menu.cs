using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{
    public void Awake()
    {
        AudioManager.Instance.Play("MainMusic");
    }

    public void Start()
    {

    }
    public void PlayGame()
    {
        AudioManager.Instance.Stop("MainMusic");
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
