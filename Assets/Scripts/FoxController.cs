using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoxController : MonoBehaviour
{
    public float dangerRadius;
    public Transform player;
    public Transform[] patrolPoints;
    public LayerMask isPlayer;
    public float speed;
    private bool withinRadius;
    private NavMeshAgent agent;
    private int destinationPoint;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        nextPoint();
    }
    void Update()
    {
        withinRadius = Physics.CheckSphere(transform.position, dangerRadius, isPlayer);

        if (!agent.pathPending && agent.remainingDistance < 0.5f) {
            nextPoint();
        }

        if (withinRadius) {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    void nextPoint() {
        if (patrolPoints.Length == 0) {
            return;
        }

        agent.destination = patrolPoints[destinationPoint].position;
        destinationPoint = (destinationPoint + 1) % patrolPoints.Length;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerHitBox")
        {
            GameManager.Instance.loseCon = true;
        }
    }
}
