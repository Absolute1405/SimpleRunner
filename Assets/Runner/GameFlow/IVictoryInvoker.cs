using System;

namespace Runner.GameFlow
{
    public interface IVictoryInvoker
    {
        event Action Victory;
    }
}

