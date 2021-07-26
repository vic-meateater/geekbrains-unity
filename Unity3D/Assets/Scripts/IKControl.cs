using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKControl : MonoBehaviour
{
    [SerializeField] private bool _isActive;
    [SerializeField] private Transform _lookObj;
    [SerializeField] private Transform _takeObj;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (_isActive)
        {
            if (_lookObj != null)
            {
                _animator.SetLookAtWeight(1f);
                _animator.SetLookAtPosition(_lookObj.position);
            }

            if(_takeObj != null)
            {
                _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
                _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
                _animator.SetIKPosition(AvatarIKGoal.LeftHand, _takeObj.position);
                _animator.SetIKRotation(AvatarIKGoal.LeftHand, _takeObj.rotation);
            }
        }
        else
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0f);
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0f);
            _animator.SetLookAtWeight(0f);
        }
    }
}
