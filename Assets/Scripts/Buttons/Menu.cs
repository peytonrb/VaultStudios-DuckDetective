using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button menuButton;
   
    void Start()
    {
        Button mButton = menuButton.GetComponent<Button>();
        mButton.onClick.AddListener(toMenu);
    }

    private void toMenu() 
    {
        AudioManager.Instance.Stop("LoseMusic");
        AudioManager.Instance.Stop("WinMusic");
        SceneManager.LoadScene(0);
    }
}
