using UnityEngine;

public class TriggerOnZoneEnter : MonoBehaviour
{
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
}
