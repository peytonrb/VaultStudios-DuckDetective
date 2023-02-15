using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LayerMask npc;
    public GameObject camPov;
    private bool inRange;
    private Coroutine LookCoroutine;
    public float rotationSpeed = 1f;
    
    private void Update()
    {
        // checks if NPC is in range
        inRange = Physics.CheckSphere(this.transform.position, 2f, npc);

        if (inRange)
        {
            GameManager.Instance.NPCInRange();
        }
        else
        {
            GameManager.Instance.npcInRange = false;
        }

        if ( GameManager.Instance.fDown)
        {
            StartRotating();
        }
    }

    public void StartRotating()
    {
        if (LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }

        LookCoroutine = StartCoroutine(LookAt());
    }

    private IEnumerator LookAt()
    {
        camPov.GetComponent<PlayerLook>().enabled = false;
        Transform Target = GameManager.Instance.frog;
        Quaternion lookRotation = Quaternion.LookRotation(Target.position - transform.position);
        Quaternion camLookRotation = Quaternion.LookRotation(Target.position - camPov.transform.position);

        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);

            camPov.transform.rotation = Quaternion.Slerp(camPov.transform.rotation, camLookRotation, time);
            //camPov.transform.eulerAngles = new Vector3(camPov.transform.eulerAngles.x, 0f, 0f);
            
            time += Time.deltaTime * rotationSpeed;
            yield return null;
        }
        //camPov.GetComponent<PlayerLook>().enabled = true;
    }
}
