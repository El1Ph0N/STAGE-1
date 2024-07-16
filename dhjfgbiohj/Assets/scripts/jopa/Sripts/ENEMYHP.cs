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

    //��� ������������ � ������ ��������
    private void OnCollisionEnter(Collision collision)
    {
        //���� �������� ������������ ������ 10
        if (collision.relativeVelocity.magnitude > 20)
        {
            //�������� ����� TakeDamage � �������� � ���� �������� �������� ������������
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
