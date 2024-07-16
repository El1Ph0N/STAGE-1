using UnityEngine;

public class _90greed : MonoBehaviour
{
    
    private float _rotationSpeed = 2f;
    private bool not = false;

    public GameObject mimi;
    public GameObject mimi1;
    public GameObject machine;

    private void OnTriggerEnter(Collider other)
    {
        Muvment mum = other.GetComponent<Muvment>();
        if (mum != null && !not)
        {
            mimi.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 90f, 0f), _rotationSpeed * Time.deltaTime);
            not = true;
            mimi.GetComponent<Muvment>().enabled = false;
            mimi.GetComponent<ZMuvment>().enabled = true;


            mimi1.SetActive(false);
            machine.SetActive(true);


            mimi.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX |
                RigidbodyConstraints.FreezeRotationX |
                RigidbodyConstraints.FreezeRotationY |
                RigidbodyConstraints.FreezeRotationZ;
        }
    }
}
