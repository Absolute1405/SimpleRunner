using System;
using System.Threading.Tasks;
using FlexEngine.Essence.AppFlow;

namespace Runner.Shared.GameFlow
{
    public class LoadState : IAppAsyncStateWithArgs<LoadStateArgs, LoadStateResult>
    {
        public Task<LoadStateResult> WaitState(LoadStateArgs args)
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            
        }
    }

    public class LoadStateArgs
    {
        
    }
    
    public class LoadStateResult
    {
        
    }
}

