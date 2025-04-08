using UnityEngine;

namespace Design_Patterns.States
{
    public class EnemyIdleSOBase : ScriptableObject
    {
        protected Enemy enemy;


        public virtual void Init(Enemy enemy)
        {
            this.enemy = enemy;
        }

        public void OnStateEnter()
        {
            OnEnter();
        }

        protected virtual void OnEnter()
        {
        }

        public void OnStateExit()
        {
            OnExit();
        }

        protected virtual void OnExit()
        {
        }

        public void OnStateUpdate()
        {
            UpdateState();
        }

        protected virtual void UpdateState()
        {
        }
    }
}