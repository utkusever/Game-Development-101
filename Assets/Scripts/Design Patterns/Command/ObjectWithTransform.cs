using UnityEngine;

namespace Design_Patterns.Command
{
    public class ObjectWithTransform : MonoBehaviour
    {
        private Commander commander;
        private IMover mover;

        private void Start()
        {
            commander = new Commander();
            mover = new CommandMovement(commander, this.transform);
        }

        private void Update()
        {
            mover.Move();
        }
    }
}