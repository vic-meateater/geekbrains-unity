using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BananaMan
{
    public class PoolObjects<T> where T : MonoBehaviour
    {
        public T _prefab {get;}
        public bool _autoExpand { get; set; }
        public Transform _containerTransform { get; set; }

        private List<T> _pool;

        public PoolObjects(T prefab, int count, Transform containerTransform)
        {
            _prefab = prefab;
            _containerTransform = containerTransform;
            
            CreatePool(count);

        }

        private void CreatePool(int count)
        {
            _pool = new List<T>();
            for (int i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = Object.Instantiate(_prefab, _containerTransform);
            createdObject.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createdObject);
            return createdObject;
        }

        public bool HasFreeElement(out T element)
        {
            foreach (var obj in _pool)
            {
                if (!obj.gameObject.activeInHierarchy)
                {
                    element = obj;
                    obj.gameObject.SetActive(true);
                    return true;
                }
            }
            element = null;
            return false;
        }

        public T GetFreeElement()
        {
            if (HasFreeElement(out var element))
                return element;
            throw new Exception($"No element {typeof(T)} available");
        }

    }
}