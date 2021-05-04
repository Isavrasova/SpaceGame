using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUp : MonoBehaviour
{
    private float _verticalAngle;
    [SerializeField] private float _mouseSensitive = 1000f;
    void Start()
    {
        _verticalAngle = Input.GetAxis("Mouse Y");
    }

    
    void Update()
    {
        transform.Rotate(_verticalAngle * _mouseSensitive * Time.fixedDeltaTime, 0f, 0f);
    }
}
