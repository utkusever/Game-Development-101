using UnityEngine;

namespace Design_Patterns.States
{
    public class StateController : MonoBehaviour
    {
        private State currentState;

        protected virtual void Update()
        {
            currentState?.UpdateState();
        }

        public virtual void ChangeState(State newState)
        {
            currentState?.OnExit();
            currentState = newState;
            newState.OnEnter();
        }
    }
}