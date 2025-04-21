using System.Collections.Generic;
using UnityEngine;

namespace Design_Patterns.Command
{
    public class Commander
    {
        private readonly Stack<ICommand> pastCommands = new();
        private readonly Stack<ICommand> futureCommands = new();

        public void AddCommand(ICommand command)
        {
            command.Execute();
            pastCommands.Push(command);
            if (futureCommands.Count > 0) futureCommands.Clear();
        }

        public void Undo()
        {
            if (pastCommands.Count == 0) return;
            ICommand command = pastCommands.Pop();
            command.Undo();
            futureCommands.Push(command);
        }

        public void Redo()
        {
            if (futureCommands.Count == 0) return;
            ICommand command = futureCommands.Pop();
            command.Execute();
            pastCommands.Push(command);
        }
    }
}