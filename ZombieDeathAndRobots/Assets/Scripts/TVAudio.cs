using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVAudio : MonoBehaviour
{
    //VARIABLES
    [SerializeField] private AudioSource _tvAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _tvAudio.volume = 0.18f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _tvAudio.volume = 0f;
        }
    }
}
