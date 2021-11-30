using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
   public GameObject[] personPrefabs;
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
    //    int personIndex = Random.Range(0, personPrefabs.Length);
       allPerson = new GameObject[numPerson];
       for(int i = 0; i < personPrefabs.Length; i++)
        {
            Vector3 relative_spawn = new Vector3(i%4, 0.30f, i/4);
            allPerson[i] = Instantiate(personPrefabs[i], transform.position + (relative_spawn * 10.0f), transform.rotation) as GameObject; 

            // Vector3 rel_spawn = new Vector3(i%10, 0.30f, i/10);
            // allPerson[i] = (GameObject) Instantiate(personPrefab1, transform.position + (rel_spawn * 10.0f), transform.rotation); 

            allPerson[i].GetComponent<Flock>().myManager = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
