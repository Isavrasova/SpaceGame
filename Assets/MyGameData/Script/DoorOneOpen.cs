using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOneOpen : MonoBehaviour
{
    public Animator anim;
    private bool key = false;

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
        if (other.tag == "Player" && key == true)
        {
            
            anim.Play("door_1_open");
        }



    }


    private void OnTriggerExit(Collider other)
    {

        anim.Play("glass_door_close");



    }
}
