using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 1.0f;
    private bool moveForward, moveBackward, moveRight, moveLeft;
    public float horizontalMove, verticalMove;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();



    }
 
    //pressing left button
    public void PointerDownLeft()
    {
        moveLeft = true;

    }
    public void PointerUpLeft()
    {
        moveLeft = false;
    }
    public void PointerDownRight()
    {
        moveRight = true;
    }
    public void PointerUpRight()
    {
        moveRight = false;
    }
    //move forward
    public void PointerDownForward()
    {
        moveForward = true;
    }
    public void PointerUpForward()
    {
        moveForward = false;
    }
    public void PointerDownBackwards()
    {
        moveBackward = true;
    }
    public void PointerUpBackwards()
    {
        moveBackward = false;
    }
  
    // Update is called once per frame
    void Update()
    {
        //Up / down movement
        /*    float forwardInput = Input.GetAxis("Vertical");
            playerRb.AddForce(Vector3.forward * speed * forwardInput);

            //Left/ right movement
            float horizontalInput = Input.GetAxis("Horizontal");
            playerRb.AddForce(Vector3.right * speed * horizontalInput);

            //Keep player in-bound on the left
            if(transform.position.x < -25) {
                transform.position = new Vector3(-25, transform.position.y, transform.position.z);
            }
            //Keep player in-bound on the right
            if(transform.position.x > 25) {
                transform.position = new Vector3(25, transform.position.y, transform.position.z);
            }*/

               
            MovementPlayer();
        
            

    }
    
    public void MovementPlayer()
    {
        if (moveLeft)
        {
            horizontalMove = -speed;
        }
        else if (moveRight)
        {
            horizontalMove = speed;
        } else
        {
            horizontalMove = 0;
        }
        if (moveForward)
        {
            verticalMove = speed;
        }else if (moveBackward)
        {
            verticalMove = -speed;
        }
        else
        {
            verticalMove = 0;
        }
    }
    private void FixedUpdate()
    {
        playerRb.velocity = new Vector3(horizontalMove, playerRb.velocity.y, verticalMove);  
        
    }
}
