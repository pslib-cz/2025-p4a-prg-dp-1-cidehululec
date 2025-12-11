using System;
using System.Collections.Generic;
using System.Text;

namespace Command_TaskManager.Commands
{
    public class ToggleCommand : ICommand
    {
        private readonly List<TaskItem> _tasks;
        private readonly int _index;
        private TaskItem _targetTask;

        public ToggleCommand(List<TaskItem> tasks, int index)
        {
            _tasks = tasks;
            _index = index;
        }

        public void Execute()
        {
            if (_index >= 0 && _index < _tasks.Count)
            {
                _targetTask = _tasks[_index];
                _targetTask.IsCompleted = !_targetTask.IsCompleted; 
                Console.WriteLine($">Stav změněn: {_targetTask}");
            }
            else
            {
                throw new IndexOutOfRangeException("Neplatné číslo úkolu.");
            }
        }

        public void Undo()
        {
            if (_targetTask != null)
            {
                _targetTask.IsCompleted = !_targetTask.IsCompleted; 
                Console.WriteLine($">UNDO: Stav vrácen zpět: {_targetTask}");
            }
        }
    }
}
