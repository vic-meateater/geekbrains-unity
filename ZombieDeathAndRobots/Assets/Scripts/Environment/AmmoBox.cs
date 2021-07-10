using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    //VARIABLES
    private int _ammo = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Pick Up Ammo");
            other.GetComponent<Player>().AmmoBoxPickUp(_ammo);
        }
        Destroy(gameObject);
    }
}
