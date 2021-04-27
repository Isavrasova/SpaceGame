using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRobot : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private Transform[] _wayPoint;
    public float waitingTime = 3;
    float patrolTimer;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        _agent.SetDestination(_wayPoint[0].position);
        
    }

    
    void Update()
    {
        Patrol();
        
    }

    void Patrol() 
    {
        
        if (_agent.remainingDistance < _agent.stoppingDistance)
        {
            _agent.SetDestination(_wayPoint[1].position);
        }
       
    }
   

}
