using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer2D
{
    public class PlayerWeaponView:MonoBehaviour
    {
        public Transform _gunPoint;
        public Transform _firePoint;
        public List<LevelObjectView> _bullets;
    }
}