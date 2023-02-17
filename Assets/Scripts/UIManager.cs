using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject fKey;
    public GameObject textBG;
    public GameObject spaceText;

    private void Awake()
    {
        fKey.SetActive(false);
        textBG.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Instance.npcInRange == true)
        {
            if (textBG.gameObject.activeInHierarchy == true)
            {
                fKey.SetActive(false);
            }
            else
            {
                fKey.SetActive(true);
            }

            if (GameManager.Instance.moveOff)
            {
                textBG.SetActive(true);
                fKey.SetActive(false);
            }
            else
            {
                textBG.SetActive(false);
            }
        }

        else 
        {
            fKey.SetActive(false);
        }
        
        if (!GameManager.Instance.typing)
        {
            spaceText.SetActive(true);
        }
        else
        {
            spaceText.SetActive(false);
        }

        if (GameManager.Instance.hasMacguffin && !GameManager.Instance.npcInRange)
        {
            fKey.SetActive(false);
        }
    }
}
