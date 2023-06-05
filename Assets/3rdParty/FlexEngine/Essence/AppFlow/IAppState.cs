using System.Threading.Tasks;

namespace FlexEngine.Essence.AppFlow
{
    public interface IAppState
    {
        void Exit();
    }

    public interface IAppStateWithArgs<T> : IAppState 
    {
        void Enter(T args);
    }

    public interface IAppStateWithoutArgs : IAppState
    {
        void Enter();
    }
    
    public interface IAppAsyncStateWithArgs<TArgs, TResult> : IAppState 
    {
        Task<TResult> WaitState(TArgs args);
    }

    public interface IAppAsyncStateWithoutArgs<TResult> : IAppState 
    {
        Task<TResult> WaitState();
    }
}
