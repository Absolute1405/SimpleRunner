namespace FlexEngine.Essence.AppFlow
{
    public interface IUpdater
    {
        void AddInstance(IUpdatable instance);
        void RemoveInstance(IUpdatable instance);
    }
}

