using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class npcChat : MonoBehaviour
{
    public TMP_Text[] chats;
    public int chatNumb;

    private void Awake()
    {
        foreach (TMP_Text text in chats)
        {
            text.gameObject.SetActive(false);
        }
        chatNumb = 0;
    }

    private void Update()
    {
        if (GameManager.Instance.npcInRange == true)
        {
            if (GameManager.Instance.moveOff && !GameManager.Instance.activeChat)
            {
                GameManager.Instance.activeChat = true;
                chats[chatNumb].gameObject.SetActive(true);
                Debug.Log(chats.Length);
                if ((chatNumb + 1) >= chats.Length && tag != "Macguffin")
                {
                    return;
                }
                else if (tag == "Macguffin")
                {
                    Debug.Log("Macguffin");
                }
                else
                {
                    chatNumb ++;
                }
            }
            else if (!GameManager.Instance.activeChat)
            {
                foreach (TMP_Text text in chats)
                {
                    if (text.gameObject.activeInHierarchy)
                    {
                        text.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
