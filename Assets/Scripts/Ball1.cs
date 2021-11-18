using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
   
    public Vector3 ballattachment;
    private Rigidbody ballRb;
    public Transform player;

    public float ballThrowingForce = 5f;
    public float ballDistance = 2f;
    private bool holdingBall = true;
    
   
    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        transform.position = ballattachment;
        ballRb.useGravity = false;
    }
  // Update is called once per frame
    void Update()
    {
       /* if (holdingBall)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
              

                ballRb.AddForce(transform.forward * ballThrowingForce);

            }
          
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = ballattachment;
            collision.transform.parent = ballRb.transform;
        }
    }
}

