using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Ball player;
    public float chasingDistance = 12f;
    public float chasingInterval = 0f;
    public float chasingTimer;

    public float speed = 8f;
    void Start()
    {
        player = GameObject.Find("Ball").GetComponent<Ball>(); 
        agent = GetComponent<NavMeshAgent>();

        agent.SetDestination(player.transform.position.normalized);


    }

    void Update()
    {
        chasingTimer -= Time.deltaTime;

        if (chasingTimer <= 0)
        {
            chasingTimer = chasingInterval;
            agent.SetDestination(player.transform.position.normalized);

        }
    }
}
