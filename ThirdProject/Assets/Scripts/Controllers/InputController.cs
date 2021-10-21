using UnityEngine;


namespace BananaMan
{
    public class InputController:IExecute
    {
        private readonly Player _player;
        private readonly Gun _gun;
        private readonly ListExecuteObject _listExecuteObject;
        private readonly string _fire = "Fire1";
        private readonly SaveDataRepository _saveDataRepository;
        private readonly KeyCode _save = KeyCode.F5;
        private readonly KeyCode _load = KeyCode.F6;

        private float _cooldown = 0f;

        public InputController(Player player, ListExecuteObject listExecuteObject, Gun gun)
        {
            _player = player;
            _gun = gun;
            _saveDataRepository = new SaveDataRepository();
            _listExecuteObject = listExecuteObject;
        }
        public void Execute()
        {
            _player.MovePlayer(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            _player.AimTowardMouse();
            if (Input.GetButton(_fire) && Time.time >= _cooldown)
            {
                _cooldown = Time.time + 1f / _gun._firerate;
                _gun.Shoot();
            }
            if (Input.GetKeyDown(_save))
            {
                _saveDataRepository.Save2(_listExecuteObject);
            }
            if (Input.GetKeyDown(_load))
            {
                _saveDataRepository.Load(_listExecuteObject);
            }
        }
    }
}