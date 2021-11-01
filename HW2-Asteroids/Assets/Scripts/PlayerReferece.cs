using UnityEngine;

namespace Asteroids
{
    public sealed class PlayerReferece
    {
        private Player _player;

        internal Player Player
        {
            get
            {
                if (_player != null) return _player;
                var gameObject = Resources.Load<Player>("Prefabs/Player");
                _player = Object.Instantiate(gameObject);
                return _player;
            }
        }
    }
}