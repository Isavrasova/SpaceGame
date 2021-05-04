using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBomb : MonoBehaviour
{
    private float _damage = 50f;
    private float thrust = 20f;
    public Rigidbody rb;
    [SerializeField]
    private float radius = 10.0F;
    [SerializeField]
    private float power = 10.0F;
    [SerializeField]
    private float _blowDelay = 7f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * thrust);
        StartCoroutine(BlowDelay());
        StopAllCoroutines();
    }

    
    IEnumerator BlowDelay()
    {
        yield return new WaitForSeconds(_blowDelay);
        Vector3 explosionPos = transform.position;

        Collider[] cols = Physics.OverlapSphere(explosionPos, 10);


        foreach (Collider col in cols)
        {

            col.GetComponent<ITakeDamage>().Damage((int)_damage);
            col.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius);

            
        }
        

        Destroy(gameObject);

    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "world")
        {
            Vector3 explosionPos = transform.position;
            collision.gameObject.GetComponent<ITakeDamage>().Damage((int)_damage);
            collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius);
            Destroy(gameObject);
        }
       *//* else
        {
            Destroy(gameObject);
        }*//*
        
    }*/


   
}
