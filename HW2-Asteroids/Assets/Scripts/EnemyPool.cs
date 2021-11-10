using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids.ObjectPool
{
    internal sealed class EnemyPool
    {
         private readonly Dictionary<string, HashSet<Enemy>> _enemyPool;
         private readonly Transform _rootPool;
         private readonly int _capacityPool;
         private EnemyReference _enemyReference;

         public EnemyPool(int capacityPool)
         {
             _enemyPool = new Dictionary<string, HashSet<Enemy>>();
             _capacityPool = capacityPool;
             if (!_rootPool)
             {
                 _rootPool = new GameObject(NameManager.POOL_AMMUNITION).transform;
             }
         }

         public Enemy GetEnemy(string type)
         {
             _enemyReference = new EnemyReference();
             Enemy result;
             switch (type)
             {
                 case "Asteroid":
                     result = GetEnemy(_enemyReference.Asteroid, GetListEnemies(type));
                     break;
                 case "EnemyStarship":
                     result = GetEnemy(_enemyReference.EnemyStarship, GetListEnemies(type));
                     break;
                 default:
                     throw new ArgumentOutOfRangeException(nameof(type), type, "Не предусмотрен в программе");
             }

             return result;
         }

         private HashSet<Enemy> GetListEnemies(string type)
         {
             return _enemyPool.ContainsKey(type) ? _enemyPool[type] : _enemyPool[type] = new HashSet<Enemy>();
         }

         private Enemy GetEnemy(Enemy enemyObject, ISet<Enemy> enemies)
         {
             
             var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
             if (enemy == null)
             {
                 for (var i = 0; i < _capacityPool; i++)
                 {
                     var instantiate = Object.Instantiate(enemyObject);
                     ReturnToPool(instantiate.transform);
                     enemies.Add(instantiate);
                 }
                 GetEnemy(enemyObject, enemies);
             }
             enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
             return enemy;
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