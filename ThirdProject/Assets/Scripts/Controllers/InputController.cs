using UnityEngine;


namespace BananaMan
{
    public class InputController:IExecute
    {
        private readonly Player _player;
        private readonly ListExecuteObject _listExecuteObject;
        private readonly KeyCode _fire = KeyCode.Mouse0;
        private readonly SaveDataRepository _saveDataRepository;
        private readonly KeyCode _save = KeyCode.F5;
        private readonly KeyCode _load = KeyCode.F6;

        public InputController(Player player, ListExecuteObject listExecuteObject)
        {
            _player = player;
            _saveDataRepository = new SaveDataRepository();
            _listExecuteObject = listExecuteObject;
        }
        public void Execute()
        {
            _player.MovePlayer(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            _player.AimTowardMouse();
            if (Input.GetKey(_fire))
            {
                _player.Fire();
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