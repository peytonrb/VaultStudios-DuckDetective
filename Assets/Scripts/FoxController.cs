using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoxController : MonoBehaviour
{
    public float dangerRadius;
    public Transform player;
    public LayerMask isPlayer;
    public float speed;
    private bool withinRadius;
    void Update()
    {
        withinRadius = Physics.CheckSphere(transform.position, dangerRadius, isPlayer);

        if (withinRadius) {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
