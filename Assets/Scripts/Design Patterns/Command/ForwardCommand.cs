using UnityEngine;

namespace Design_Patterns.Command
{
    // we can create a new class named BackwardCommand,LeftCommand etc. and call its execute method whatever
    public class ForwardCommand : ICommand
    {
        private readonly Transform transformToMove;
        private readonly Vector3 moveVector = new Vector3(0, 0, 1);

        public ForwardCommand(Transform transformToMove)
        {
            this.transformToMove = transformToMove;
            moveVector *= Random.Range(1, 5);
        }

        public void Execute()
        {
            var position = transformToMove.position;
            position += moveVector;
            transformToMove.position = position;
        }

        public void Undo()
        {
            var position = transformToMove.position;
            position -= moveVector;
            transformToMove.position = position;
        }
    }
}