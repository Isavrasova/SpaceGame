using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOneOpen : MonoBehaviour
{
    public Animator anim;
    public static bool key1 = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Awake()
    {
        
        anim.Play("door_1_closed");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && key1 == true)
        {
            
            anim.Play("door_1_open");
        }



    }


    private void OnTriggerExit(Collider other)
    {

        anim.Play("door_1_close");



    }
}
