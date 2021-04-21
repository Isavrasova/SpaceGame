using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDroneGuard : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    private Transform _target;
    
    [SerializeField]
    private float _time = 5f;

    private float timer;
    void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    

    private void Start()
    {
        
    }
    void Update()
    {
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
