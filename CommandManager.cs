using System;
using System.Collections.Generic;
using System.Text;

namespace Command_TaskManager
{
    public class CommandManager
    {
        private readonly Stack<ICommand> _history = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            try
            {
                command.Execute();
                _history.Push(command); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba při provádění: {ex.Message}");
            }
        }

        public void UndoLast()
        {
            if (_history.Count > 0)
            {
                var command = _history.Pop();
                command.Undo();
            }
            else
            {
                Console.WriteLine("Není co vrátit (historie je prázdná).");
            }
        }
    }
}
