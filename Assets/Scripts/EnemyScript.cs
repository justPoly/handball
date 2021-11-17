using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody enemyBody;

    public float moveSpeed = 5f;
    Vector3 localScale;
    bool movingRight = true;
    public CharacterController mContoller;

    // Start is called before the first frame update
    void Start()
    {
        enemyBody = GetComponent<Rigidbody>();
        localScale = transform.localScale;


    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 3)
        {
            movingRight = false;
        }
        else if(transform.position.x < 3)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            moveRight();

        }
        else
        {
            moveLeft();

        }
        //enemyBody.velocity = new Vector3(2f, enemyBody.velocity.y, 2f);
        
    }

    private void moveLeft()
    {
        movingRight = false;
        localScale.x = 3;
        transform.localScale = localScale;
        enemyBody.velocity = new Vector3(localScale.x * moveSpeed,enemyBody.velocity.y, 2f);
       
    }

    private void moveRight()
    {
        movingRight = false;
        localScale.x = 3;
        transform.localScale = localScale;
        enemyBody.velocity = new Vector3(localScale.x * moveSpeed,enemyBody.velocity.y, 2f);
    }
}
