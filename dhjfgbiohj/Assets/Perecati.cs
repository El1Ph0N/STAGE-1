using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perecati : MonoBehaviour
{
    Rigidbody rb;
    //public GameObject FIstcol;
    //public GameObject Secondcol ;
    public float spdash;
   // public Animator animator;
    //public Animation DAsh;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            rb.AddForce(transform.forward * spdash, ForceMode.Impulse);
            //animator.Play("DASH");
            //FIstcol.SetActive(false);
            //Secondcol.SetActive(true);
            
        }

    }
   // private void end()
   // {
        
    //}
}
