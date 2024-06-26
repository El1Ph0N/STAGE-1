using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private bool stat = false;
    private bool endanimation = true;
    public Collider colid; 

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        colid.enabled = false;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && endanimation)
        {           
            endanimation = false;
            stat = true;
            animator.SetBool("Att", stat);
        }
    }
    private void STAT()
    {
        colid.enabled = true;
    }
    private void Stopped()
    {
        
        colid.enabled = false;
         
}
    private void Stoppedebd()
    {
        animator.SetBool("Att", stat);
        stat = false;
        endanimation = true;
    }
}
