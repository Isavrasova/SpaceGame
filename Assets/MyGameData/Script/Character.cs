using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, ITakeDamage
{
    public float speed = 3f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private GameObject bombSpawn;
    [SerializeField] private float _mouseSensitive = 100f;
    private Transform _target;

    private float _boostDamage = 5f;
    private float _angle;

    

    
    private Vector3 _direction = Vector3.zero;
    [SerializeField] private int _health = 300;
    [SerializeField] private Rigidbody _rb;
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
        Cursor.lockState = CursorLockMode.Confined;
        _rb = GetComponent<Rigidbody>();
    }
    
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Fire();
        
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        

        _angle = Input.GetAxis("Mouse X");


        if (Input.GetButton("Jump"))
        {
            
            _rb.AddForce(0, 10f, 0, ForceMode.Impulse);
        }

        if (Input.GetButtonDown("Fire1"))
            BombIt();

    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
       
    }

    private void Rotate()
    {
        transform.Rotate(0f, _angle * _mouseSensitive * Time.fixedDeltaTime, 0f);
        
    }

   
    private void Move()
    {
        
        var _speed = _direction.normalized * Time.fixedDeltaTime * speed;
        
        transform.Translate(_speed);
    }

    private void BombIt()
    {
        var t = gameObject.GetComponent<CapsuleCollider>();
        var bomb = GameObject.Instantiate(bombPrefab, bombSpawn.transform.position, bombSpawn.transform.rotation).GetComponent<ThrowBomb>();
    }

    private void Fire()
    {
        var t = gameObject.GetComponent<CapsuleCollider>();
        var bullet = GameObject.Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation).GetComponent<Bullet>();
        bullet.GetComponent<Bullet>().Booster(_boostDamage);
        
    }

    public void Damage(int damage)
    {
        _health -= damage;
    }

    public void EnergyUp()
    {
        _health = 300;
    }
}
