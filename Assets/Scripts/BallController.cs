using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector3 ballattachment;
    private Rigidbody ballRb;
    public Transform player;

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
