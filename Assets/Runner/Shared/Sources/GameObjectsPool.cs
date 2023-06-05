using System;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Shared
{
    public class GameObjectsPool
    {
        public IReadOnlyCollection<GameObject> Items => _items;
        private readonly HashSet<GameObject> _items;
        private readonly Transform _root;

        public GameObjectsPool(IEnumerable<GameObject> objects, Transform root)
        {
            _root = root;
            _items = new HashSet<GameObject>(objects);
        }

        public void Push(GameObject item)
        {
            if (!_items.Contains(item))
                throw new InvalidOperationException($"Gameobject {item.name} is not presented in Pool");
            
            item.SetActive(false);
            item.transform.SetParent(_root);
        }

        public void PushAll()
        {
            foreach (var item in _items)
            {
                if (!item.activeSelf)
                    continue;
                
                item.SetActive(false);
                item.transform.SetParent(_root);
                item.transform.localPosition = Vector3.zero;
            }
        }

        public GameObject Pop(Transform parent)
        {
            foreach (var item in _items)
            {
                if (item.activeSelf)
                    continue;

                item.SetActive(true);
                item.transform.SetParent(parent);
                return item;
            }

            throw new InvalidOperationException("Pool is empty");
        }
    }
}

