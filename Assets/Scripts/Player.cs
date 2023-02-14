using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LayerMask npc;
    private bool inRange;
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
    }
}
