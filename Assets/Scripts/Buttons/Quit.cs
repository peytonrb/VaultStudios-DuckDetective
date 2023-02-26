using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public Button quitButton;
   
    void Start()
    {
        Button qButton = quitButton.GetComponent<Button>();
        qButton.onClick.AddListener(quitGame);
    }

    private void quitGame() {
        Application.Quit();
    }
}