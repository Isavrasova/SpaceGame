using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Patrol : MonoBehaviour, ITakeDamage
{

    [SerializeField] private Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    Animator anim;
    [SerializeField] private int _health = 1000;
    [SerializeField] private LayerMask _mask;
    
    private Transform _target;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    private float timer;
    private float _time = 2.2f;
    [SerializeField] private float _speed = 0.5f;
    
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        anim = gameObject.GetComponent<Animator>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        anim.SetBool("Open_Anim", true);


    }
    void Start()
    {
        

        
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        
        if (points.Length == 0 || agent.autoBraking == true)
            return;

        if (_health <= 0)
        {
            
            return;

        }

        anim.SetBool("Walk_Anim", true);
        agent.destination = points[destPoint].position;

        
        destPoint = (destPoint + 1) % points.Length;
       
    }


    void Update()
    {

        if (_health <= 0)
        {
            DoorTwoOpen.robotIsDead = true;

            anim.SetBool("Walk_Anim", false);
            anim.SetBool("Open_Anim", false);
            StopAllCoroutines();

        }

        LookForPlayer();
        if (!agent.pathPending && agent.remainingDistance < 0.5f && _health > 0)
            GotoNextPoint();
        
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
            
            agent.autoBraking = true;
            
            StartCoroutine(FollowPlayer());
            
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            agent.autoBraking = true;

            StartCoroutine(FollowPlayer());
        }
    }
    private IEnumerator FollowPlayer()
    {
        while (true)
        {

            

            agent.speed = 5f;

            
            agent.destination = _target.position;
            if (agent.remainingDistance <= 7f)
            {
                agent.speed = 1.2f;
                
                Fire();
            }


                yield return new WaitForSeconds(3f);
            

        }


       


    }
    private void Fire()
    {
        if (timer > _time && _health > 0)
        {
            timer = 0f;
            var bullet = GameObject.Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation).GetComponent<Bullet>();
            

        }
        else
        {
            timer += Time.deltaTime;
        }





    }
}
