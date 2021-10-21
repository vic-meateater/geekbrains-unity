namespace BananaMan
{
    public abstract class PlayerActions : BaseCharacter
    {
        public abstract void MovePlayer(float moveX, float moveY, float moveZ);
        public abstract void AimTowardMouse();
        public abstract void Fire();
        public abstract void SpeedUp(int value);

    }
}

