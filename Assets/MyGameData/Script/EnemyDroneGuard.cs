using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDroneGuard : MonoBehaviour, ITakeDamage
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    private Transform _target;
    public Animator anim;
    private bool _awake = false;
    [SerializeField]
    private float _time = 5f;
    [SerializeField] private int _health = 100;
    [SerializeField] private float _speed = 0.5f;
    private float timer;
    void Awake()
    {
        
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("ShutDown");
    }
    void Update()
    {
        if (_awake)
        {
            RotateTowards();

            if (timer > _time)
            {
                timer = 0f;
                var bullet = GameObject.Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.identity).GetComponent<Bullet>();
                bullet.Target = _target;
            }
            else
            {
                timer += Time.deltaTime;
            }
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
