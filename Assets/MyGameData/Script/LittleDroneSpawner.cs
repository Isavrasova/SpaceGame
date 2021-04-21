using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleDroneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject LittleDrone_Guard;
    public Transform[] droneWaypoints;

    void Start()
    {
        for (int i = 0; i < droneWaypoints.Length; i ++)
        {
            GameObject.Instantiate(LittleDrone_Guard, droneWaypoints[i].transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
