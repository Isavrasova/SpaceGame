using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDroneGuard : MonoBehaviour, ITakeDamage
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn1;
    [SerializeField] private Transform bulletSpawn2;
    private Transform _target;
    public Animator anim;
    private bool _awake = false;
    [SerializeField]
    private float _time = 5f;
    [SerializeField] private int _health = 300;
    [SerializeField] private float _speed = 0.5f;
    private float timer;
    private int fullhealth;
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

    void Awake()
    {
        fullhealth = _health;
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("ShutDown");
        anim.Play("WakeUp");
    }
    void Update()
    {
        if (_health < fullhealth)
        {
            
            _awake = true;
        }

        if (_awake)
        {
            RotateTowards();

            if (timer > _time)
            {
                timer = 0f;
                var bullet1 = GameObject.Instantiate(bulletPrefab, bulletSpawn1.transform.position, Quaternion.identity).GetComponent<EnemyBullet>();
                var bullet2 = GameObject.Instantiate(bulletPrefab, bulletSpawn2.transform.position, Quaternion.identity).GetComponent<EnemyBullet>();
                bullet1.Target = _target;
                bullet2.Target = _target;


            }
            else
            {
                timer += Time.deltaTime;
            }
        }
         if (_health <= 0)
        {
            anim.Play("Destroyed");
            Destroy(gameObject, 7f);
        }
            
    }

    private void RotateTowards()
    {
        var direction = _target.position - transform.position;
        var newDirection = Vector3.RotateTowards(transform.forward, direction, _speed * Time.deltaTime, 0);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.Play("WakeUp");
            _awake = true;
            
            
        }
        
    }

    public void Damage(int damage)
    {
        _health -= damage;
    }

}
