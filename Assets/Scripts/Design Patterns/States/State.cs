using System;

namespace Design_Patterns.States
{
    public abstract class State // might be interface too, 
    {
        protected StateController stateController;

        public virtual void OnEnter()
        {
        }

        public virtual void UpdateState()
        {
        }

        public virtual void OnExit()
        {
        }
    }
}