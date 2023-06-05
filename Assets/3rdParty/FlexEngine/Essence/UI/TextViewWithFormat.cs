using TMPro;
using UnityEngine;

namespace FlexEngine.Essence.UI
{
    public class TextViewWithFormat : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private string _format;

        public void SetText(string text)
        {
            var value = string.Format(_format, text);
            _text.SetText(value);
        }

        public void SetColor(Color color)
        {
            _text.color = color;
        }

        public void SetText(int text)
        {
            var value = string.Format(_format, text);
            _text.SetText(value);
        }
    }
}

