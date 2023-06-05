using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FlexEngine.Dialogs
{
    public class DialogYesNo : Dialog<DialogYesNoArgs, DialogYesNoResult>
    {
        [SerializeField] private TMP_Text _messageText;
        [SerializeField] private Button _yesButton;
        [SerializeField] private Button _noButton;

        protected override void OnOpen(DialogYesNoArgs args)
        {
            _yesButton.onClick.AddListener(OnYesClick);
            _noButton.onClick.AddListener(OnNoClick);

            _messageText.SetText(args.Message);
        }

        protected override void OnClose(DialogYesNoResult result)
        {
            _yesButton.onClick.RemoveListener(OnYesClick);
            _noButton.onClick.RemoveListener(OnNoClick);
        }

        private void OnYesClick()
        {
            SetResult(new DialogYesNoResult(true));
        }
        
        private void OnNoClick()
        {
            SetResult(new DialogYesNoResult(false));
        }
    }

    public class DialogYesNoArgs
    {
        public DialogYesNoArgs(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }

    public class DialogYesNoResult
    {
        public DialogYesNoResult(bool confirmation)
        {
            Confirmation = confirmation;
        }

        public bool Confirmation { get; }
    }
}

