using System;
using UnityEngine;
namespace BananaMan
{
    [Serializable]
    public sealed class MiniMap:MonoBehaviour, IExecute
    {
        private Transform _player;

        [SerializeField]private Camera _miniMapCamera;
        public Camera MiniMapCamera => _miniMapCamera;

        public MiniMap(Transform player)
        {
            _player = player;
            _miniMapCamera = new Camera();
        }

        private void Awake()
        {
            _miniMapCamera = MiniMapCamera;
            _miniMapCamera.transform.parent = null;
            _miniMapCamera.transform.rotation = Quaternion.Euler(90.0f, 0, 0);
            _miniMapCamera.transform.position = _player.position + new Vector3(0, 5.0f, 0);
            var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");
            _miniMapCamera.targetTexture = rt;
        }
        // private void Start()
        // {
        //     _player = Camera.main.transform;
        //     transform.parent = null;
        //     transform.rotation = Quaternion.Euler(90.0f, 0, 0);
        //     transform.position = _player.position + new Vector3(0, 5.0f, 0);
        //
        //     var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");
        //
        //     GetComponent<Camera>().targetTexture = rt;
        // }

        // private void Update()
        // {
        //     var newPosition = _player.position;
        //     newPosition.y = transform.position.y;
        //     transform.position = newPosition;
        //     transform.rotation = Quaternion.Euler(90, _player.eulerAngles.y, 0);
        // }

        public void Execute()
        {
            var newPosition = _player.position;
            newPosition.y = _miniMapCamera.transform.position.y;
            _miniMapCamera.transform.position = newPosition;
            _miniMapCamera.transform.rotation = Quaternion.Euler(90, _player.eulerAngles.y, 0);
        }
    }
}