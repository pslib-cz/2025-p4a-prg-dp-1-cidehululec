using System;
using System.Collections.Generic;
using System.Text;

namespace Command_TaskManager
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
