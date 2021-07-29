using UnityEngine;

public class AnimationToRagDoll : MonoBehaviour
{
    private Rigidbody[] _rbRagDoll;

    // Start is called before the first frame update
    void Start()
    {
        _rbRagDoll = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rb in _rbRagDoll)
        {
            rb.tag = "Enemy";
            rb.isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) RagdollActivate();
    }

    //Почему-то не работает 
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Debug.Log(collision.gameObject.tag);
            RagdollActivate();
        }
    }
    public void RagdollActivate()
    {
        foreach (Rigidbody rb in _rbRagDoll) rb.isKinematic = false;
        GetComponent<Animator>().enabled = false;
    }
}
