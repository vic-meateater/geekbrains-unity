using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Button : MonoBehaviour
{
    //VARIABLES

    [SerializeField] Transform _jumper;
    [SerializeField] Transform _button;
    private bool _buttonNotPushed = true;
    private void OnTriggerEnter(Collider other)
    {
        if (_buttonNotPushed)
        {
            _button.position = new Vector3(_button.position.x, _button.position.y - 0.2f, _button.position.z);
            _jumper.position = new Vector3(_jumper.position.x, _jumper.position.y - 8.25f, _jumper.position.z);
            _buttonNotPushed = false;
        }
    }
}
