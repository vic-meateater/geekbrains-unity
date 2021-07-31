using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;

    public void TakeDamage(int damage, RaycastHit hit, Camera fpsCam, float attackForce)
    {
        var _ragDoll = hit.collider.GetComponentInParent<AnimationToRagDoll>();
        _health -= damage;
        if (_health <= 0)
        {
            _ragDoll.RagdollActivate();
            hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(fpsCam.transform.TransformDirection(Vector3.forward) * attackForce);
            Player.FindObjectOfType<Camera>().GetComponent<ChangeEffectsSettings>().ChangeSettings();
        }

    }
}
