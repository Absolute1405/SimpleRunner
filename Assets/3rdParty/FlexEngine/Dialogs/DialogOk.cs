using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FlexEngine.Dialogs
{
    public class DialogOk : Dialog<DialogOkArgs, VoidType>
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _okButton;
        
        protected override void OnOpen(DialogOkArgs args)
        {
            _text.SetText(args.Message);
            _okButton.onClick.AddListener(OnOkClicked);
        }

        protected override void OnClose(VoidType result)
        {
            _okButton.onClick.RemoveAllListeners();
        }

        private void OnOkClicked()
        {
            SetResult(new VoidType());
        }
    }

    public class DialogOkArgs
    {
        public DialogOkArgs(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}

