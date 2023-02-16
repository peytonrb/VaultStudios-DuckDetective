using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject fKey;
    public GameObject textBG;
    public TMP_Text frogChat;

    private void Awake()
    {
        fKey.SetActive(false);
        textBG.SetActive(false);
        frogChat.gameObject.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Instance.npcInRange == true)
        {
            if (frogChat.gameObject.activeInHierarchy == true)
            {
                fKey.SetActive(false);
            }
            else
            {
                fKey.SetActive(true);
            }

            if (GameManager.Instance.fDown)
            {
                textBG.SetActive(true);
                frogChat.gameObject.SetActive(true);
                fKey.SetActive(false);
            }
        }

        else 
        {
            fKey.SetActive(false);
        }
        
    }
}
