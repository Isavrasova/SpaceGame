using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float _damage = 3f;
    private Transform _target;
    private Vector3 _targetPosition;

    [SerializeField]
    private float _speed = 4f;

    public Transform Target
    {
        set
        {
            _target = value;
            _targetPosition = _target.position;
        }
    }
    
    void Start()
    {
        Destroy(gameObject, 30f);
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    public void Booster(float newDamage)
    {
        _damage = newDamage;
    }
}
