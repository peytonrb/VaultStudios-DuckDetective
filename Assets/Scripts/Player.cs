using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject npc;
    public GameObject camPov;
    public GameObject froggo;
    private bool inRange;
    private Coroutine LookCoroutine;
    public float rotationSpeed = 1f;
    
    private void Awake()
    {
        froggo.SetActive(false);
    }

    private void Update()
    {
        if (inRange)
        {
            GameManager.Instance.NPCInRange();
        }
        else
        {
            GameManager.Instance.npcInRange = false;
        }

        if (GameManager.Instance.fDown && npc != null)
        {
            StartRotating(npc);
        }

        if (GameManager.Instance.moveOff)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !GameManager.Instance.typing)
            {
                MoveOn();
            }
        }

        if (GameManager.Instance.hasMacguffin)
        {
            froggo.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7) //checks if the collided object is on layer 7 or NPC
        {
            inRange = true;
            npc = other.gameObject;
            npc.GetComponent<npcChat>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7) //checks if the collided object is on layer 7 or NPC
        {
            inRange = false;
            npc.GetComponent<npcChat>().enabled = false;
            npc = null;
        }

    }

    public void StartRotating(GameObject npc)
    {
        if (LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }

        LookCoroutine = StartCoroutine(LookAt(npc));
    }

    private IEnumerator LookAt(GameObject target)
    {
        camPov.GetComponent<PlayerLook>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        GameManager.Instance.MoveOff();
        Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        Quaternion camLookRotation = Quaternion.LookRotation(target.transform.position - camPov.transform.position);

        float time = 0;
        while (time < 1)
        {
            if(Input.GetKeyDown(KeyCode.Space) && !GameManager.Instance.typing)
            {
                time = 1;
            }
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);

            camPov.transform.rotation = Quaternion.Slerp(camPov.transform.rotation, camLookRotation, time);
            
            time += Time.deltaTime * rotationSpeed;
            yield return null;
        }
    }

    public void MoveOn()
    {
        GameManager.Instance.tempPlayerLookX = camPov.transform.eulerAngles.x;
        GameManager.Instance.activeChat = false;
        GameManager.Instance.moveOff = false;
        camPov.GetComponent<PlayerLook>().enabled = true;
        GetComponent<PlayerMovement>().enabled = true;
    }
}
