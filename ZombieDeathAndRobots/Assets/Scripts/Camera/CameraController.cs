using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // VARIABLES
    [SerializeField] private float _mouseSens;
    float xRotation = 0f;

    //REFERENCES
    
    private Transform parent;
    void Start()
    {
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        parent.Rotate(Vector3.up * mouseX);
        parent.Rotate(Vector3.up, mouseX);
    }
}
