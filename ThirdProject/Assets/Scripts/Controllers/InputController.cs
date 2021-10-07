using UnityEngine;


namespace BananaMan
{
    public class InputController:IExecute
    {
        private readonly Player _player;
        private readonly KeyCode _fire = KeyCode.Mouse0;

        public InputController(Player player)
        {
            _player = player;
        }
        public void Execute()
        {
            _player.MovePlayer(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            _player.AimTowardMouse();
            if (Input.GetKey(_fire))
            {
                _player.Fire();
            }
        }
    }
}