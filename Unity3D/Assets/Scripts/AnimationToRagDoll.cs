using UnityEngine;

public class AnimationToRagDoll : MonoBehaviour
{
    private Rigidbody[] _rbRagDoll;

    void Awake()
    {
        _rbRagDoll = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rb in _rbRagDoll)
        {
            rb.tag = "Enemy";
            rb.isKinematic = true;
        }
    }

    public void RagdollActivate()
    {
        foreach (Rigidbody rb in _rbRagDoll) rb.isKinematic = false;
        GetComponent<Animator>().enabled = false;
    }
}
