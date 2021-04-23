
using UnityEngine;

public class BatteryCharge : MonoBehaviour
{
    [SerializeField] private GameObject Battery_big;
    public Transform[] batteryWaypoint;
    private Transform _target;
    
    
    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Character>().EnergyUp();
            Destroy(gameObject);

            
        }
    }
}
