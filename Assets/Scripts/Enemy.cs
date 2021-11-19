using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Ball ball;
    public float chasingDistance = 12f;
    public float chasingInterval = 2f;
    public float chasingTimer;

    public float speed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball").GetComponent<Ball>();
        Debug.Log(ball);
        agent = GetComponent<NavMeshAgent>(); 

        agent.SetDestination(ball.transform.position);


    }

    // Update is called once per frame
    void Update()
    {
        chasingTimer -= Time.deltaTime;

        if (chasingTimer <= 0)
        {
            chasingTimer = chasingInterval;
            agent.SetDestination(ball.transform.position);

        }
    }

}