using System;
using System.Collections.Generic;
using System.Text;

namespace Command_TaskManager
{
    public class TaskItem
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            return $"[{(IsCompleted ? "X" : " ")}] {Description}";
        }
    }
}
