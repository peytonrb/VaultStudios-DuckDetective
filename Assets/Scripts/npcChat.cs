using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class npcChat : MonoBehaviour
{
    public TMP_Text[] chats;
    public TMP_Text winChat;
    public int chatNumb;
    private bool pickup;
    private bool spokenTo;

    private void Awake()
    {
        deactivateStuff();
        chatNumb = 0;
        pickup = false;
    }

    private void Update()
    {
        if (GameManager.Instance.npcInRange == true)
        {
            if (GameManager.Instance.moveOff && !GameManager.Instance.activeChat)
            {
                GameManager.Instance.activeChat = true;
                if (GameManager.Instance.hasMacguffin && tag != "Macguffin")
                {
                    winChat.gameObject.SetActive(true);
                }
                else
                {
                    chats[chatNumb].gameObject.SetActive(true);
                }
                
                if ((chatNumb + 1) >= chats.Length && tag != "Macguffin")
                {
                    return;
                }
                else if (tag == "Macguffin")
                {
                    GameManager.Instance.typing = true;
                    pickup = true;
                }
                else
                {
                    chatNumb ++;
                }
            }
            else if (!GameManager.Instance.activeChat)
            {
                deactivateStuff();
            }
        }

        if (!GameManager.Instance.typing && pickup && Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (!gameObject.activeInHierarchy)
        {
            GameManager.Instance.hasMacguffin = true;
            GameManager.Instance.npcInRange = false;
        }
        foreach (TMP_Text text in chats)
        {
            if (text.gameObject.activeInHierarchy)
            {
                text.gameObject.SetActive(false);
            }
        }
    }

    private void deactivateStuff()
    {
        foreach (TMP_Text text in chats)
        {
            if (text.gameObject.activeInHierarchy)
            {
                text.gameObject.SetActive(false);
            }
        }
        if (winChat != null)
        {
            winChat.gameObject.SetActive(false);
        }
    }
}
