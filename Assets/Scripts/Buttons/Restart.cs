using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Button restartButton;

    void Start()
    {
        Button rButton = restartButton.GetComponent<Button>();
        rButton.onClick.AddListener(restartGame);
    }

    private void restartGame() {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGM();
        }
        AudioManager.Instance.Stop("LoseMusic");
        AudioManager.Instance.Stop("WinMusic");
        SceneManager.LoadScene(1);
    }


}
