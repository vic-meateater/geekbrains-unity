using UnityEngine;

public class ParalaxManager
{ 
    private Transform _camera;
    private Transform _back;
    private Transform _mid;
    private Transform _front;
    private Vector3 _backStartPosition;
    private Vector3 _midStartPosition;
    private Vector3 _frontStartPosition;
    private Vector3 _cameraStartPosition;
    private const float _coef = 1.3f;

    public ParalaxManager(Transform camera, Transform back,Transform mid, Transform front)
    {
        _camera = camera;
        _back = back;
        _mid = mid;
        _front = front;
        _cameraStartPosition = _camera.transform.position;
        _backStartPosition = _back.transform.position;
        _midStartPosition = _mid.transform.position;
        _frontStartPosition = _front.transform.position;
    }

    public void Update()
    {
        _back.position = _backStartPosition + (_camera.position - _cameraStartPosition) * _coef;
        _mid.position = _midStartPosition + (_camera.position - _cameraStartPosition) * 1f;
        _front.position = _frontStartPosition + (_camera.position - _cameraStartPosition) * 0.5f;
    }

}
