using System;

namespace Runner.GameFlow
{
    public interface IContinueInvoker
    {
        event Action Continue;
    }
}
