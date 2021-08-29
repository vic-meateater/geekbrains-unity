using UnityEngine;

namespace BananaMan
{
    public class Player : PlayerActions
    {
        private void Update()
        {
            MovePlayer();
            AimTowardMouse();
            if(Input.GetKeyDown(KeyCode.Mouse0))
                Shoot();
        }
    }
}
