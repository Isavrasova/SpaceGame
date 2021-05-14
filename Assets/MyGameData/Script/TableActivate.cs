using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableActivate : MonoBehaviour
{
    [SerializeField] private GameObject EnterCodeMenu;
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            EnterCodeMenu.SetActive(true);
        }



    }
}
