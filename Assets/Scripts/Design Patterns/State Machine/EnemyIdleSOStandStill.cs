using UnityEngine;

namespace Design_Patterns.States
{
    [CreateAssetMenu(menuName = "Create EnemyIdleSOStandStill", fileName = "EnemyIdleSOStandStill", order = 0)]
    public class EnemyIdleSOStandStill : EnemyIdleSOBase
    {
        private StateController stateController;

        public override void Init(Enemy enemy)
        {
            base.Init(enemy);
            Debug.Log(base.enemy.name);
        }

        protected override void OnEnter()
        {
            Debug.Log("I'm just standing here");
        }

        protected override void UpdateState()
        {
            // if (target)
            // {
            //     stateController.ChangeState(enemy.EnemyAttackState);
            // }
        }
    }
}