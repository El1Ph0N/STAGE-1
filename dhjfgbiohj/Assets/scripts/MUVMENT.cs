using GLTF.Schema;
using UnityEditor.Animations;
using UnityEngine;

public class MUVMENT : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 0.5f;
    private Vector3 moveVector;
    public float jump_forse = 0f;
    bool isGrounded = true;
    public float spdash = 10f;
    [SerializeField] Animator _animator;
    private bool NORUN = true;
     float uskor= 1f;
    

    float _rotationSpeed = 6f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _animator.SetBool("RICKROLL", false);
        //_animation.Stop("Roll");
    }

    private void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 DD = transform.TransformDirection(Vector3.down);

            if (Physics.Raycast(transform.position, DD, 2f))
            {
                _animator.SetBool("Jump", true);
                rb.AddForce(transform.up * jump_forse, ForceMode.Impulse);
            }

            if (Physics.Raycast(transform.position, DD, 0.5f))
            {
                _animator.SetBool("Jump", false);
            }
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
    void FixedUpdate()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + moveVector * speed * Time.fixedDeltaTime * uskor);
    }
    private void stopplay()
    {
        _animator.SetBool("RICKROLL", true);
        NORUN = true;
    }
}