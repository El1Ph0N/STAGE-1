using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.AI;

public class ENEMYAI : MonoBehaviour
{
    public List<Transform> patrolPoints;


    private NavMeshAgent _navMeshAgent;


    void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
    }

    void Update()
    { PatrolUpdate(); }     
        
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance == 0)
        {
            PickNewPatrolPoint();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
}
