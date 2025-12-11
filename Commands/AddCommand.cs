using System;
using System.Collections.Generic;
using System.Text;

namespace Command_TaskManager.Commands
{
        public class AddCommand : ICommand
    {
        private readonly List<TaskItem> _tasks;
        private readonly TaskItem _task;

        public AddCommand(List<TaskItem> tasks, string description)
        {
            _tasks = tasks;
            _task = new TaskItem { Description = description, IsCompleted = false };
        }

        public void Execute()
        {
            _tasks.Add(_task);
            Console.WriteLine($">Úkol přidán: '{_task.Description}'");
        }

        public void Undo()
        {
            _tasks.Remove(_task);
            Console.WriteLine($">UNDO: Úkol '{_task.Description}' byl odebrán.");
        }
    }
}
