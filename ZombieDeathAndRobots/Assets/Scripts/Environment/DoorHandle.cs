using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandle : MonoBehaviour
{

    //VARIABLES
    [SerializeField] private Doors _door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("In Handle AREA");
            _door.Open();
        }
    }
}
