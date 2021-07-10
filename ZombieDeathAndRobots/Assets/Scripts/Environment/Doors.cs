using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    //VARIABLES

    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _doorOpenRotation;

    private bool _isOpen = false;
    
    
    void Update()
    {
        if (_isOpen)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(_doorOpenRotation),_speed * Time.deltaTime);
        }
    }

    public void Open()
    {
        _isOpen = true;
    }
    public void Close()
    {
        _isOpen = false;
    }
}
