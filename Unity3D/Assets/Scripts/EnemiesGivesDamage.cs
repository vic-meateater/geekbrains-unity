using UnityEngine;

public class EnemiesGivesDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<ITakeDamage>().TakeDamage(20);
    }
}
