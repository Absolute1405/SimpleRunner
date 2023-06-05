using System;
using System.Collections.Generic;
using UnityEngine;

namespace FlexEngine.Patterns.Pool
{
    public class Pool<T> where T: IPoolable
    {
        private readonly List<T> _items = new List<T>();
        private readonly Transform _root;

        public Pool(IEnumerable<T> items, Transform root)
        {
            foreach (var item in items)
            {
                Push(item);
            }
        }
        
        public Pool(Transform root)
        {
            _root = root;
        }

        public void Push(T item)
        {
            _items.Add(item);
            item.SetActive(false);
            item.SetParent(_root);
        }

        public T Pop(Transform parent)
        {
            foreach (var item in _items)
            {
                if (item.Active)
                    continue;

                item.SetActive(true);
                item.SetParent(parent);
                _items.Remove(item);
                return item;
            }

            throw new InvalidOperationException("Pool is empty");
        }
    }
}

