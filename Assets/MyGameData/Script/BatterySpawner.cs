
using UnityEngine;

public class BatterySpawner : MonoBehaviour
{
    [SerializeField] private GameObject Battery_big;
    public Transform[] batteryWaypoint;
    void Start()
    {
        int r = Random.Range(0, batteryWaypoint.Length - 1);
        GameObject.Instantiate(Battery_big, batteryWaypoint[r].transform.position, Quaternion.identity);
    }

    
}
