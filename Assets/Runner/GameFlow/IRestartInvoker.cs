using System;

namespace Runner.GameFlow
{
    public interface IRestartInvoker
    {
        event Action Restart;
    }
}

