using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Runner.Shared
{
    public class AddressableCachedFactory<T> : MonoBehaviour where T: MonoBehaviour
    {
        private GameObjectsPool _pool;
        private GameObject _cachedTemplate;

        public async Task CreateCache(int cacheSize, AssetReference reference)
        {
            List<GameObject> objects = new List<GameObject>();
            _cachedTemplate = await LoadTemplateFromReference(reference);

            for (int i = 0; i < cacheSize; i++)
            {
                GameObject obj = InstantiateFromCachedTemplate();
                objects.Add(obj);
            }

            _pool = new GameObjectsPool(objects, transform);
            _pool.PushAll();
            
            Addressables.Release(_cachedTemplate);
        }

        protected T GetCachedInstance(Transform container)
        {
            GameObject obj = _pool.Pop(container);
            T result = obj.GetComponent<T>();

            if (result == null)
                throw new InvalidOperationException(
                    $"Cant find component of type {typeof(T).Name} at cached gameobject {obj.name}");

            return result;
        }
        
        private GameObject InstantiateFromCachedTemplate()
        {
            var gameObj = Instantiate(_cachedTemplate);
            return gameObj;
        }

        private async Task<GameObject> LoadTemplateFromReference(AssetReference reference)
        {
            var result = await Addressables.LoadAssetAsync<GameObject>(reference).Task;
            return result;
        }

        public void ReturnSpawnedInstancesToCache()
        {
            _pool.PushAll();
        }
    }
}

