using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKControl : MonoBehaviour
{
    [SerializeField] private bool _isActive;
    [SerializeField] private Transform _lookObj;
    [SerializeField] private Transform _takeObj;
    [SerializeField] private LayerMask _lookAtLayer;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        var lookAtObject = Physics.CheckSphere(transform.position, 2, _lookAtLayer);
        if (_isActive && lookAtObject)
        {
            _animator.SetLookAtWeight(1f);
            _animator.SetLookAtPosition(_lookObj.position);

            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
            _animator.SetIKPosition(AvatarIKGoal.LeftHand, _takeObj.position);
            _animator.SetIKRotation(AvatarIKGoal.LeftHand, _takeObj.rotation);
        }
        else
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0f);
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0f);
            _animator.SetLookAtWeight(0f);
        }
    }
}
