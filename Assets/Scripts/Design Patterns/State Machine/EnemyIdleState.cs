using UnityEngine;

namespace Design_Patterns.States
{
    public class EnemyIdleState : EnemyState
    {
        public EnemyIdleState(Enemy enemy) : base(enemy)
        {
        }

        public override void OnEnter()
        {
            Debug.Log("enemy idle enter");
            enemy.EnemyIdleBaseInstance.OnStateEnter();
        }

        public override void UpdateState()
        {
            Debug.Log("enemy idle update");
            enemy.EnemyIdleBaseInstance.OnStateUpdate();
        }

        public override void OnExit()
        {
            Debug.Log("enemy idle exit");
            enemy.EnemyIdleBaseInstance.OnStateExit();
        }
    }
}