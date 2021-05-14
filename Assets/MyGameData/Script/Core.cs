using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Core : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int _health = 3000;
    public static bool isOverloaded;

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
        isOverloaded = false;
    }

void Update()
{
    if (_health <= 0 && isOverloaded == true)
    {
            

        Destroy(gameObject);
            SceneManager.LoadScene(3);


        }
}

public void Damage(int damage)
{
    if (isOverloaded == true)
        {
            _health -= damage;
        }
       
}
}

