using UnityEngine;

public class movePlayer : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 0.5f;
    private Vector3 moveVector;
    public float jump_forse = 0f;
    bool isGrounded = true;
    public float spdash = 10f;

          
 
            
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 DD = transform.TransformDirection(Vector3.down);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, DD, 1.5f))
            {
                rb.AddForce(transform.up * jump_forse, ForceMode.VelocityChange);
            }
                
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            rb.AddForce(moveVector * spdash, ForceMode.Impulse);
            //animator.Play("DASH");
            //FIstcol.SetActive(false);
            //Secondcol.SetActive(true);

        }

    }
    void FixedUpdate()
    {
        moveVector.x = Input.GetAxis("Horizontal");        
        rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);

        
    }
}