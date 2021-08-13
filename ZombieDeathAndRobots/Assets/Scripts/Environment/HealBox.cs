using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBox : MonoBehaviour
{
    //VARIABLES
    private int _heal = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Pick Up Heal");
            other.GetComponent<Player>().HealBoxPickUp(_heal);
        }
        Destroy(gameObject);
    }
}
