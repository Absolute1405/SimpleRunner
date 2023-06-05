using System.Collections.Generic;
using FlexEngine.Essence.Animations;
using Runner.Level;
using Runner.Shared;
using UnityEngine;

namespace Runner.UI
{
    public class UIStatistics : MonoBehaviour
    {
        [SerializeField] private BoolAnimator _animator;
        [SerializeField] private UIStatisticsItemFactory _factory;

        private IReadOnlyPlayerStatistics _statistics;
        private List<UIStatisticsItem> _statisticsItems = new List<UIStatisticsItem>();

        public async void Initialize(IReadOnlyPlayerStatistics statistics, LevelLineChunkModel[] chunkModels)
        {
            _statistics = statistics;

            foreach (var model in chunkModels)
            {
                if (!model.ShowInStatistic)
                    continue;
                
                UIStatisticsItem item = await _factory.CreateFrom(model);
                _statisticsItems.Add(item);
            }
        }

        public void Refresh()
        {
            foreach (var item in _statisticsItems)
            {
                int amount = _statistics.GetAmountOf(item.Id);
                item.Setup(amount);
            }
        }

        public void SetVisible(bool value)
        {
            _animator.SetValue(value);
        }
    }
}

