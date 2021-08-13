
using UnityEngine;

public class Ememies : MonoBehaviour
{
    private float _health=50;
    public void TakeDamage(int damage, RaycastHit hit)
    {
        var _ragDoll = hit.collider.GetComponentInParent<AnimationToRagDoll>();
        _health -= damage;
        if (_health <= 0)
        {
            _ragDoll.RagdollActivate();
            hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward));
        }

    }
}
