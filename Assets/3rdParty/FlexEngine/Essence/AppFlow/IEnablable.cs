namespace FlexEngine.Essence.AppFlow
{
    public interface IEnablable
    {
        bool enabled { get; }
        public void SetEnabled(bool value);
    }
}

