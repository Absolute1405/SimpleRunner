using TMPro;
using UnityEngine;

namespace FlexEngine.Essence.UI
{
    public class TextView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void SetText(string text)
        {
            _text.SetText(text);
        }

        public void SetColor(Color color)
        {
            _text.color = color;
        }

        public void SetText(int text)
        {
            _text.SetText(text.ToString());
        }
    }
}

