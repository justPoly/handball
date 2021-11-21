using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5.0f;
    public Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Up / down movement
      // float forwardInput =joystick.Vertical; // Input.GetAxis("Vertical");
     /* if(joystick.Horizontal >= 0.2f || joystick.Horizontal <= -0.2f && joystick.Vertical >= 0.2f || joystick.Vertical <= -0.2f)
        {
            Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
            playerRb.AddForce(direction * speed * Time.deltaTime);
        }*/

     /* if(joystick.Horizontal >= 0.2f)
        {
            playerRb.AddForce(Vector3.right * speed * joystick.Horizontal);
        }
      else if( joystick.Horizontal <= -0.2f)
        {
            playerRb.AddForce(Vector3.left * speed * joystick.Horizontal);

        }
        else if(joystick.Vertical >= 0.2f)
        {
            playerRb.AddForce(Vector3.forward * speed * joystick.Vertical);
        }
      else if(joystick.Vertical <= -0.2f)
        {
            playerRb.AddForce(Vector3.back * speed * joystick.Vertical);
        }
      
       // playerRb.AddForce(Vector3.forward * speed * joystick.Vertical);

        //Left/ right movement
        //float horizontalInput =  joystick.Horizontal;//Input.GetAxis("Horizontal");
        //playerRb.AddForce(Vector3.right * speed *horizontalInput);
        
        //Keep player in-bound on the left
        if(transform.position.x < -25) {
            transform.position = new Vector3(-25, transform.position.y, transform.position.z);
        }
        //Keep player in-bound on the right
        if(transform.position.x > 25) {
            transform.position = new Vector3(25, transform.position.y, transform.position.z);
        }*/
    }

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
        playerRb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        if (transform.position.x < -25)
        {
            transform.position = new Vector3(-25, transform.position.y, transform.position.z);
        }
        //Keep player in-bound on the right
        if (transform.position.x > 25)
        {
            transform.position = new Vector3(25, transform.position.y, transform.position.z);
        }
    }
}
