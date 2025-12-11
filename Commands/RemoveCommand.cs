using System;
using System.Collections.Generic;
using System.Text;

namespace Command_TaskManager.Commands
{
    public class RemoveCommand : ICommand
    {
        private readonly List<TaskItem> _tasks;
        private readonly int _index;
        private TaskItem _removedTask;

        public RemoveCommand(List<TaskItem> tasks, int index)
        {
            _tasks = tasks;
            _index = index;
        }

        public void Execute()
        {
            if (_index >= 0 && _index < _tasks.Count)
            {
                _removedTask = _tasks[_index];
                _tasks.RemoveAt(_index);
                Console.WriteLine($">Úkol odstraněn: '{_removedTask.Description}'");
            }
            else
            {
                throw new IndexOutOfRangeException("Neplatné číslo úkolu.");
            }
        }

        public void Undo()
        {
            if (_removedTask != null)
            {
                _tasks.Insert(_index, _removedTask);
                Console.WriteLine($">UNDO: Úkol '{_removedTask.Description}' vrácen zpět.");
            }
        }
    }
}
