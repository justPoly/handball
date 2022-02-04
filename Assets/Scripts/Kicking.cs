using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kicking : MonoBehaviour
{
   
    public Animator animator;
    Passing passing;
    public bool isKicking = false;
    
    // Start is called before the first frame update
   void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
        passing =GetComponent<Passing>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
       // isKicking = true;
        if (isKicking==true)
        {
            
            animator.SetTrigger("Kick");
            animator.SetBool("isKicking", true);
         //   passing.shoot = true;
        }

        if(isKicking == false)
        {
            animator.SetBool("isKicking", false);

           // passing.shoot = false;
        }


    }
    public void KickBall()
    {
        animator.SetTrigger("Kick");
        animator.SetBool("isKicking", true);
        
    }

}
