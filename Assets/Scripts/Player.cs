using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform npc;
    public GameObject camPov;
    private bool inRange;
    private Coroutine LookCoroutine;
    public float rotationSpeed = 1f;
    
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

        if (GameManager.Instance.fDown)
        {
            StartRotating(npc);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7) //checks if the collided object is on layer 7 or NPC
        {
            inRange = true;
        }
        npc = other.gameObject.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7) //checks if the collided object is on layer 7 or NPC
        {
            inRange = false;
        }
    }

    public void StartRotating(Transform npc)
    {
        if (LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }

        LookCoroutine = StartCoroutine(LookAt(npc));
    }

    private IEnumerator LookAt(Transform target)
    {
        camPov.GetComponent<PlayerLook>().enabled = false;
        Quaternion lookRotation = Quaternion.LookRotation(target.position - transform.position);
        Quaternion camLookRotation = Quaternion.LookRotation(target.position - camPov.transform.position);

        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);

            camPov.transform.rotation = Quaternion.Slerp(camPov.transform.rotation, camLookRotation, time);
            
            time += Time.deltaTime * rotationSpeed;
            yield return null;
        }
    }
}
