using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockManager myManager;
    public float speed;
    bool turning = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(myManager.minSpeed, myManager.maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //determine the bounding
        Bounds b = new  Bounds(myManager.transform.position, myManager.moveLimits * 2);

        //Turn back if out of bound
        if(!b.Contains(transform.position))
        {
            turning = true;
        }
        else
            turning = false;
        if(turning) 
        {
           Vector3 direction = myManager.transform.position - transform.position;
           transform.rotation = Quaternion.Slerp(transform.rotation,
                                                     Quaternion.LookRotation(direction),
                                                     myManager.rotationSpeed * Time.deltaTime); 
        }  

        ApplyRules();
        transform.Translate(0, 0, Time.deltaTime * speed);
    }

    void ApplyRules()
    {
        GameObject[] gos;
        gos = myManager.allPerson;

        Vector3 vcentre = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.01f;
        float nDistance;
        int groupSize = 0;

        foreach (GameObject go in gos)
        {
            if(go != this.gameObject)
            {
                nDistance = Vector3.Distance(go.transform.position, this.transform.position);
                if(nDistance <= myManager.neighbourDistance)
                {
                    vcentre += go.transform.position;
                    groupSize++;

                    if(nDistance < 10.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }

                    Flock anotherFlock = go.GetComponent<Flock>();
                    gSpeed = gSpeed + anotherFlock.speed;
                }
            }
        }

        if(groupSize > 0)
        {
            vcentre = vcentre/groupSize;
            speed = gSpeed/groupSize;

            Vector3 direction = (vcentre + vavoid) - transform.position;
            if(direction != Vector3.zero)
               transform.rotation = Quaternion.Slerp(transform.rotation,
                                                     Quaternion.LookRotation(direction),
                                                     myManager.rotationSpeed * Time.deltaTime);
        }
    }
}
