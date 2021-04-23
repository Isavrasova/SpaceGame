using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, ITakeDamage
{
    public float speed = 3f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] private float _mouseSensitive = 100f;
    private Transform _target;

    private float _boostDamage = 5f;
    private float _angle;
    private Vector3 _direction = Vector3.zero;
    [SerializeField] private int _health = 300;
    
    public int Health
    {
        set
        {
            _health = value;
        }
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Fire();
        
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        

        _angle = Input.GetAxis("Mouse X");
        
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

    

    private void Fire()
    {
        var t = gameObject.GetComponent<CapsuleCollider>();
        var bullet = GameObject.Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.identity).GetComponent<Bullet>();
        bullet.GetComponent<Bullet>().Booster(_boostDamage);
        //bullet.Target
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
