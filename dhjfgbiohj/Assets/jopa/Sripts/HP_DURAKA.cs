using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HP_DURAKA : MonoBehaviour
{
    public float HP = 100;
    public Slider Slider;
    public float damage = 20;
    float trimer = 1;
    float timer = 1;
    private void Start()
    {
        Slider.value = HP;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (HP <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<ENEMYAI>() != null)
        {
            if (timer > trimer)
            {
                HP -= damage;
                Slider.value = HP;
                timer = 0;
            }
        }
    }
}