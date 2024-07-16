using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMYHP : MonoBehaviour
{
    public float maxHealth = 30;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    //При столкновении с другим объектом
    private void OnCollisionEnter(Collision collision)
    {
        //Если скорость столкновения больше 10
        if (collision.relativeVelocity.magnitude > 20)
        {
            //Вызываем метод TakeDamage и передаем в него значение скорости столкновения
            TakeDamage(15);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
