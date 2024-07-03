using UnityEngine;

public class _90greed : MonoBehaviour
{
    public GameObject mimi;
    float _rotationSpeed = 2f;
    bool not = false;
    public GameObject mimi1;
    public GameObject machine;

    private void OnTriggerEnter(Collider other)
    {
        MUVMENT mum = other.GetComponent<MUVMENT>();
        if (mum != null && !not)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            not = true;
            mimi.GetComponent<MUVMENT>().enabled = false;
            mimi.GetComponent<ZMUVMENT>().enabled = true;
            mimi1.SetActive(false);
            machine.SetActive(true);
        }
    }
}
