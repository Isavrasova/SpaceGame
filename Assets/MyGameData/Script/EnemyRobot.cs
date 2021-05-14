using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRobot : MonoBehaviour, ITakeDamage
{
    private NavMeshAgent _agent;
    [SerializeField] private Transform[] _wayPoint;
    public float waitingTime = 3;
    float patrolTimer;
    Animator anim;
    [SerializeField] private int _health = 400;

    [SerializeField] private LayerMask _mask;
    [SerializeField] private Transform _player;
    private Transform _target;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
       
        anim = gameObject.GetComponent<Animator>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        anim.SetBool("Open_Anim", true);


    }
    void Start()
    {
        
        //_agent.SetDestination(_wayPoint[0].position);
        

        StartCoroutine(Patrol());
    }

    
    void Update()
    {
        //Patrol();
        LookForPlayer();
        
    }

    /*void Patrol() 
    {
        
        if (_agent.remainingDistance < _agent.stoppingDistance)
        {
            _agent.SetDestination(_wayPoint[1].position);
            anim.SetBool("Open_Anim", false);
            anim.SetBool("Open_Anim", true);
            anim.SetBool("Walk_Anim", true);
        }
       
    }*/

    private IEnumerator Patrol()
    {
        while(true)
        {
            
            for (var i = 0; i < _wayPoint.Length; i++)

            {
                anim.SetBool("Walk_Anim", true);
                _agent.SetDestination(_wayPoint[i].position);
                if (_agent.remainingDistance < _agent.stoppingDistance)
                    anim.SetBool("Walk_Anim", false);
                yield return new WaitForSeconds(3f);
            }
            
        }
        

       


    }

    public void Damage(int damage)
    {
        _health -= damage;
    }

    private void LookForPlayer()
    {
        RaycastHit hit;
        bool isHit = Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, Mathf.Infinity); 
        if (isHit && hit.collider.tag == "Player")
        {
            Debug.Log("Found");
        }
        else
        {
            Debug.Log("Not Found");
        }
    }

}
