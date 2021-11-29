using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
   public GameObject personPrefab;
   public int numPerson = 2;
   public GameObject[] allPerson;
   public Vector3 moveLimits = new Vector3(10, 5, 10);
    
   [Header("Person Settings")]
   [Range(0.0f, 5.0f)]
   public float minSpeed;
   [Range(0.0f, 5.0f)]
   public float maxSpeed;
   [Range(1.0f, 10.0f)]
   public float neighbourDistance;
   [Range(0.0f, 5.0f)]
   public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
       allPerson = new GameObject[numPerson];
       for(int i = 0; i < numPerson; i++)
        {
            Vector3 relative_spawn = new Vector3(i%4, 0.30f, i/4);
            allPerson[i] = (GameObject) Instantiate(personPrefab, transform.position + (relative_spawn * 10.0f), transform.rotation); 

            allPerson[i].GetComponent<Flock>().myManager = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
