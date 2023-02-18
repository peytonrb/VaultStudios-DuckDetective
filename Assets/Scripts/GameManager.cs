using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public bool hasMacguffin;

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
