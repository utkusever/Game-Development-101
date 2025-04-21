using UnityEngine;

namespace Design_Patterns.Command
{
    public class RightCommand : ICommand
    {
        private readonly Transform transformToMove;
        private readonly Vector3 moveVector = new Vector3(1, 0, 0);

        public RightCommand(Transform transformToMove)
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