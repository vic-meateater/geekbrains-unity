using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnZoneEnter : MonoBehaviour
{
    //VARIABLES
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private Material _material;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<AudioSource>().Stop();
            other.GetComponent<AudioSource>().clip = _audioClip;
            other.GetComponent<AudioSource>().Play();
            RenderSettings.skybox = _material;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
