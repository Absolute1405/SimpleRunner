using System;
using UnityEngine;
using UnityEngine.UI;

namespace FlexEngine.Essence.UI
{
    [RequireComponent(typeof(Button))]
    public abstract class ButtonBase : MonoBehaviour
    {
        public event Action Clicked;
        
        private void Awake()
        {
            var button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            Clicked?.Invoke();
            OperateClick();
        }

        protected abstract void OperateClick();
    }
}

