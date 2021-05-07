using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTwoOpen : MonoBehaviour
{
    public Animator anim;
    public static bool key2 = false;
    public static bool robotIsDead = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Awake()
    {

        anim.Play("door_2_closed");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && key2 == true && robotIsDead == true)
        {

            anim.Play("door_2_open");
        }



    }


    private void OnTriggerExit(Collider other)
    {

        anim.Play("door_2_close");



    }
}
