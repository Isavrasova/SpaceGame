using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float _damage = 3f;
    private Transform _target;
    private Vector3 _targetPosition;
    private bool _isTarget = false;

    [SerializeField]
    private float _speed = 4f;

    public Transform Target
    {
        set
        {
            _target = value;
            _targetPosition = _target.position;
            _isTarget = true;
        }
    }
    
    void Start()
    {
        Destroy(gameObject, 30f);
    }

    
    /*void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }*/

    void FixedUpdate()
    {
        if (_isTarget)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.fixedDeltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward * 50f, _speed * Time.fixedDeltaTime);
    }

    public void Booster(float newDamage)
    {
        _damage = newDamage;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<ITakeDamage>().Damage((int)_damage);
            Destroy(gameObject);
        }
    }
}
