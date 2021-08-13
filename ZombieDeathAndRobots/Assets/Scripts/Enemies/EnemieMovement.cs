using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieMovement : MonoBehaviour
{
    Animator _Animator;
    // Start is called before the first frame update
    void Start()
    {
        _Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void FixedUpdate()
    //{
    //    _Animator.SetBool("isRunning", true);
    //}
}
