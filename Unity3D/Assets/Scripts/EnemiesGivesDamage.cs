using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesGivesDamage : MonoBehaviour
{
    //VARIABLES
    //[SerializeField] public Transform _player;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<ITakeDamage>().TakeDamage(20);
    }
}
