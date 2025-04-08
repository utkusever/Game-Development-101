using UnityEngine;

namespace Design_Patterns.States
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private StateController stateController;

        [SerializeField] private EnemyIdleSOBase enemyIdleSoBase; //Attach Stand Still
        public EnemyIdleSOBase EnemyIdleBaseInstance { get; private set; }

        public EnemyIdleState
            EnemyIdleState { get; private set; } // state reference to change this enemy state from other classes.

        private void Awake()
        {
            // this wont create new scriptable objects it just creates instances of classes for each enemy
            EnemyIdleBaseInstance = Instantiate(enemyIdleSoBase); // It's stand still SO
            EnemyIdleState = new EnemyIdleState(this);
        }

        private void Start()
        {
            EnemyIdleBaseInstance.Init(this);
            stateController.ChangeState(EnemyIdleState);
        }
    }
}