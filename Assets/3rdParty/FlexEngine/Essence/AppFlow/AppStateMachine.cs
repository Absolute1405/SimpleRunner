using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlexEngine.Essence.AppFlow
{
    public class AppStateMachine : IAppStateMachine
    {
        private readonly Dictionary<Type, IAppState> _states = new Dictionary<Type, IAppState>();
        private IAppState _currentState;
        

        public void SetState<TState>() where TState : IAppStateWithoutArgs
        {
            _currentState?.Exit();
            _currentState = _states[typeof(TState)];
            (_currentState as IAppStateWithoutArgs).Enter();
        }

        public void SetState<TState, TArgs>(TArgs args) where TState: IAppStateWithArgs<TArgs> 
        {
            _currentState?.Exit();
            _currentState = _states[typeof(TState)];
            (_currentState as IAppStateWithArgs<TArgs>).Enter(args);
        }
        
        public async Task<TResult> WaitState<TState, TResult>() where TState : IAppAsyncStateWithoutArgs<TResult>
        {
            _currentState?.Exit();
            _currentState = _states[typeof(TState)];
            var result = await (_currentState as IAppAsyncStateWithoutArgs<TResult>).WaitState();
            return result;
        }

        public async Task<TResult> WaitState<TState, TArgs, TResult>(TArgs args) where TState: IAppAsyncStateWithArgs<TArgs, TResult> 
        {
            _currentState?.Exit();
            _currentState = _states[typeof(TState)];
            var result = await (_currentState as IAppAsyncStateWithArgs<TArgs, TResult>).WaitState(args);
            return result;
        }

        public void AddState<TState>(TState state) where TState : IAppState
        {
            var key = typeof(TState);
            if (_states.ContainsKey(key))
                throw new InvalidOperationException("Cant add duplicate app state");
            
            _states.Add(key, state);
        }
    }

    public interface IAppStateMachine
    {
        void SetState<TState>() where TState : IAppStateWithoutArgs;
        void SetState<TState, TArgs>(TArgs args) where TState : IAppStateWithArgs<TArgs>;
        Task<TResult> WaitState<TState, TResult>() where TState : IAppAsyncStateWithoutArgs<TResult>;
        Task<TResult> WaitState<TState, TArgs, TResult>(TArgs args) where TState : IAppAsyncStateWithArgs<TArgs, TResult>;
    }
}

