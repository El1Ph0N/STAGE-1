using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atac : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
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
        
        if ( Input.GetMouseButtonDown(0) && endanimation && animator.GetBool("Jump") == false ) 
        {
            endanimation = false;
            animator.SetBool("Att1", true);
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

        animator.SetBool("Att1", false);
        endanimation = true;
    }
}
