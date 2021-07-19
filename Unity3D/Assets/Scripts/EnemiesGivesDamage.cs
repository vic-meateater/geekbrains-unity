using UnityEngine;

public class EnemiesGivesDamage : MonoBehaviour
{
    //[SerializeField] public Transform _player;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<ITakeDamage>().TakeDamage(20);
    }
}
