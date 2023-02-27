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
        SceneManager.LoadScene(1);
    }


}
