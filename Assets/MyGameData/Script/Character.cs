using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 3f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletSpawn;

    private float _boostDamage = 5f;

    private Vector3 _direction = Vector3.zero;
    private void Awake()
    {

    }

    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Fire();
        
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        _direction.y = Input.GetAxis("Jump");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var _speed = _direction.normalized * Time.fixedDeltaTime * speed;
        transform.Translate(_speed);
    }

    private void LateUpdate()
    {

    }

    private void Fire()
    {
        var t = gameObject.GetComponent<CapsuleCollider>();
        var bullet = GameObject.Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Booster(_boostDamage);
    }
}
