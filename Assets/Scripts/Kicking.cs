using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kicking : MonoBehaviour
{
   
    public Animator animator;
    //Passing passing;
    public bool isKicking = false;
    
    // Start is called before the first frame update
   void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
       //passing = GetComponent<Passing>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        isKicking = true;
        if (isKicking==true)
        {
            isKicking = false;
            animator.SetBool("isKicking", true);
        }

        if(isKicking == false)
        {
            animator.SetBool("isKicking", false);
            isKicking = false;
        }


    }

}
