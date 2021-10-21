using UnityEngine;
namespace BananaMan
{
    public sealed class MiniMap:IExecute
    {
        private Transform _player;
        private Camera _miniMapCamera;

        public MiniMap(Transform player, Camera miniMapCamera)
        {
            _player = player;
            _miniMapCamera = miniMapCamera;
            _miniMapCamera.transform.parent = null;
            _miniMapCamera.transform.rotation = Quaternion.Euler(90.0f, 0, 0);
            _miniMapCamera.transform.position = _player.position + new Vector3(0, 5.0f, 0);
            var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");
            _miniMapCamera.targetTexture = rt;
        }
        
        public void Execute()
        {
            var newPosition = _player.position;
            newPosition.y = _miniMapCamera.transform.position.y;
            _miniMapCamera.transform.position = newPosition;
            _miniMapCamera.transform.rotation = Quaternion.Euler(90, _player.eulerAngles.y, 0);
        }
    }
}