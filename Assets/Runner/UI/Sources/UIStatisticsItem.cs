using FlexEngine.Essence.UI;
using FlexEngine.Patterns.Pool;
using UnityEngine;
using UnityEngine.UI;

namespace Runner.UI
{
    public class UIStatisticsItem : MonoBehaviour, IPoolable
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextViewWithFormat _amountView;
        
        public string Id { get; private set; }

        public void Initialize(string id, Sprite sprite)
        {
            Id = id;
            _icon.sprite = sprite;
        }
        
        public void Setup(int amount)
        {
            _amountView.SetText(amount);
        }

        public bool Active { get; }
        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }
    }
}

