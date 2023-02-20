using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRaccoon : MonoBehaviour
{
    public Transform endPos;
    public Transform player;

    private void Update()
    {
        if (player != null && endPos != null)
        {
            if (Vector3.Distance(player.position, transform.position) > 10 && transform.position != endPos.transform.position)
            {
                Debug.Log("MovePos");
                transform.position = endPos.transform.position;
                transform.eulerAngles = new Vector3(0, 130, 0);
            }
        }
    }
}
