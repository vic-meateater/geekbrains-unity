using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTerrainShipTrigger : MonoBehaviour
{
    //VARIABLES
    [SerializeField] private AudioSource _audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        _audioSource.Play();
        }
    }

}
