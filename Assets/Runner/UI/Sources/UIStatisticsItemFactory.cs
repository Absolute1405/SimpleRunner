using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Runner.Level;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Runner.UI
{
    public class UIStatisticsItemFactory : MonoBehaviour
    {
        [SerializeField] private UIStatisticsItem _template;
        [SerializeField] private Transform _container;

        private List<Sprite> _loadedCache = new List<Sprite>();

        public async Task<UIStatisticsItem> CreateFrom(LevelLineChunkModel model)
        {
            UIStatisticsItem item = Instantiate(_template, _container);
            Sprite preview = await Addressables.LoadAssetAsync<Sprite>(model.UIPreview).Task;
            item.Initialize(model.ID, preview);
            return item;
        }

        private void OnDestroy()
        {
            foreach (var sprite in _loadedCache)
            {
                Addressables.Release(sprite);
            }
        }
    }
}

