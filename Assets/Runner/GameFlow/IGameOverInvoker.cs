using System;

namespace Runner.GameFlow
{
    public interface IGameOverInvoker
    {
        event Action GameOver;
    }
}

