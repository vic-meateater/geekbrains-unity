using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{

    //VARIABLES
    [SerializeField] private float _jumpHeight = 12;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.GetComponent<PlayerMovement>().Jump(_jumpHeight);
    }
}
