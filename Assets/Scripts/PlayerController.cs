using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Up / down movement
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Vector3.forward * speed * forwardInput);

        //Left/ right movement
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.right * speed * horizontalInput);

        //Keep player in-bound on the left
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.rigidbody);
            collision.transform.parent = transform;
        }
    }

}
