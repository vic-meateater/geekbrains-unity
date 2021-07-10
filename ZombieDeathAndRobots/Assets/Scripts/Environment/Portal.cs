using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    //VARIABLES
    [SerializeField] Transform _teleportOut;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = _teleportOut.transform.position;
    }
}
