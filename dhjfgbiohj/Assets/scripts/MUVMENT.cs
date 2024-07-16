
using System.Runtime.CompilerServices;
using UnityEngine;

public class Muvment : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 2f;
    private Vector3 moveVector;
    private float jump_forse = 50f;
    private float spdash = 30f;
    [SerializeField] Animator _animator;
    private float uskor= 1f;
    private bool not_end = false;
    private bool app = false;
    private float _rotationSpeed = 6f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _animator.SetBool("RICKROLL", false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !not_end )
        {
            rb.AddForce(transform.right * spdash, ForceMode.Impulse);
            not_end = true;
            _animator.SetBool("RICKROLL", true);
            Debug.Log("жмал");
        }

        Vector3 DD = transform.TransformDirection(Vector3.down);

        if (!Physics.Raycast(transform.position, DD, 4f) && !app)
        {
            rb.velocity = Vector3.zero;
            app = true;
        }
        else if (Physics.Raycast(transform.position, DD, 4f))
        {
            app = false;
        }


        float horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 DD1 = transform.TransformDirection(Vector3.down);

            if (Physics.Raycast(transform.position, DD1, 2f))
            {
                _animator.SetBool("Jump", true);

                rb.AddForce(transform.up * jump_forse, ForceMode.Impulse);
            }

        }
        
        if (Physics.Raycast(transform.position, DD, 0.07f))
        {

            _animator.SetBool("Jump", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && horizontal != 0)
        {
            uskor = 1.4f;
            _animator.SetBool("RUN", true);           
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            uskor = 1f;
            _animator.SetBool("RUN", false);
        }


        _animator.SetFloat("Speed", moveVector.magnitude);





        if (horizontal > 0f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), _rotationSpeed * Time.deltaTime);
        }
        else if (horizontal < 0f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, -180f, 0f), _rotationSpeed * Time.deltaTime);
        }

    }
    private void FixedUpdate()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + moveVector * speed * Time.fixedDeltaTime * uskor);
    }
    private void stopplay()
    {
        _animator.SetBool("RICKROLL", false);
        not_end = false;
    }
    
}