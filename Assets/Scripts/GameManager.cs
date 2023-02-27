using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } 
    // This makes GameManager accessible to any script in the project using GameManager.Instance.(whatever public things you want to access)  

    public bool fDown; // Bool Checking if F key is down
    public bool npcInRange; // Bool Checking if an NPC is in Range
    public bool moveOff;
    public float tempPlayerLookX;
    public bool activeChat;
    public bool typing;
    public bool typingSound;
    public bool hasMacguffin;
    public bool winCon;
    public bool loseCon;

    private void Awake()
    {
        // This moves the current GameManager to DontDestroyOnLoad and deletes any other GameManagers
        if (Instance != null) 
        {
            DestroyImmediate(gameObject);
        } 
        else 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);   
        }

        fDown = false;
        npcInRange = false;
        moveOff = false;
        typing = false;
        hasMacguffin = false;
        winCon = false;
    }

    private void Update()
    {
        if (winCon && !typing && SceneManager.GetActiveScene().name != "WinScreen" && Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.Instance.Stop("LevelMusic");
            SceneManager.LoadScene("WinScreen");
        }
        else if (loseCon && SceneManager.GetActiveScene().name != "LoseScreen")
        {
            AudioManager.Instance.Stop("LevelMusic");
            SceneManager.LoadScene("LoseScreen");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (typing && !typingSound)
        {
            AudioManager.Instance.Play("TextSound");
            typingSound = true;
        }
        else if (typingSound && !typing)
        {
            AudioManager.Instance.Stop("TextSound");
            typingSound = false;
        }
    }

    public void MoveOff()
    {
        moveOff = true;
    }

    public void NPCInRange()
    {
        npcInRange = true;
        if(Input.GetKeyDown(KeyCode.F))
        {
            fDown = true;
        }
        else
        {
            fDown = false;
        }
    }
}
