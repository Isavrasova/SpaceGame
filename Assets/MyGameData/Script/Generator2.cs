using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator2 : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int _health = 800;
    [SerializeField] private GameObject brokenProjector;
    [SerializeField] private GameObject projector2place;

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
            DoorTwoOpen.key2 = true;

            Destroy(gameObject);

            GameObject.Instantiate(brokenProjector, projector2place.transform.position, projector2place.transform.rotation);
        }
    }

    public void Damage(int damage)
    {
        _health -= damage;
    }
}
