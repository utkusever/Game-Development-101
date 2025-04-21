using UnityEngine;

namespace Design_Patterns.Command
{
    public class CommandMovement : IMover
    {
        private readonly Commander commander;
        private readonly Transform transform;

        public CommandMovement(Commander commander, Transform transform)
        {
            this.commander = commander;
            this.transform = transform;
        }

        public void Move()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                commander.AddCommand(new ForwardCommand(transform));
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                commander.Undo();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                commander.AddCommand(new RightCommand(transform));
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                commander.Redo();
            }
        }
    }
}