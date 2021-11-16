using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    
    
   public Transform ball;
    private Vector3 offset;

   
    void Start()
    {
        offset = transform.position - ball.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + ball.position.z);
        transform.position = newPosition;

    }
}

