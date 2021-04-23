using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("glass_door_open", true);
            anim.Play("glass_door_open");
        }



    }

    private void OnTriggerExit(Collider other)
    {
        
          anim.Play("glass_door_close");


        
    }
}
