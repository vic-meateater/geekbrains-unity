using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids.ObjectPool
{
internal sealed class BulletPool
     {
         private readonly Dictionary<string, HashSet<Bullet>> _bulletPool;
         private readonly Transform _rootPool;
         private readonly BulletReference _bulletReference;
         private readonly int _capacityPool;

         public BulletPool(int capacityPool)
         {
             _bulletReference = new BulletReference();
             _bulletPool = new Dictionary<string, HashSet<Bullet>>();
             _capacityPool = capacityPool;
             if (!_rootPool)
             {
                 _rootPool = new GameObject(NameManager.POOL_AMMO).transform;
             }
         }

         public Bullet GetBullet(string type)
         {
             Bullet result;
             switch (type)
             {
                 case "Bullet":
                     result = GetBullet(GetListBullets(type));
                     break;
                 default:
                     throw new ArgumentOutOfRangeException(nameof(type), type, "Не предусмотрен в программе");
             }

             return result;
         }

         private HashSet<Bullet> GetListBullets(string type)
         {
             return _bulletPool.ContainsKey(type) ? _bulletPool[type] : _bulletPool[type] = new HashSet<Bullet>();
         }

         private Bullet GetBullet(HashSet<Bullet> bullets)
         {
             var bullet = bullets.FirstOrDefault(a => !a.gameObject.activeSelf);
             if (bullet == null)
             {
                 var bulletRef = _bulletReference.Bullet;
                 for (var i = 0; i < _capacityPool; i++)
                 {
                     var instantiate = Object.Instantiate(bulletRef);
                     ReturnToPool(instantiate.transform);
                     bullets.Add(instantiate);
                 }

                 GetBullet(bullets);
             }
             bullet = bullets.FirstOrDefault(a => !a.gameObject.activeSelf);
             return bullet;
         }

         private void ReturnToPool(Transform transform)
         {
             transform.localPosition = Vector3.zero;
             transform.localRotation = Quaternion.identity;
             transform.gameObject.SetActive(false);
             transform.SetParent(_rootPool);
         }

         public void RemovePool()
         {
             Object.Destroy(_rootPool.gameObject);
         }
     }
}