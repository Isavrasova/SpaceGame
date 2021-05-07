using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator1 : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int _health = 400;
    [SerializeField] private GameObject brokenProjector;
    [SerializeField] private GameObject projector1place;

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
   

    
    void Update()
    {
        if (_health <= 0)
        {
            DoorOneOpen.key1 = true;

            Destroy(gameObject);

            GameObject.Instantiate(brokenProjector, projector1place.transform.position, projector1place.transform.rotation);
        }
    }

    public void Damage(int damage)
    {
        _health -= damage;
    }
}
