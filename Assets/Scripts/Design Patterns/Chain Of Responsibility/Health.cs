using UnityEngine;

namespace Design_Patterns.Chain_Of_Responsibility
{
    public class Health : MonoBehaviour, IDamageable
    {
        private AttackSystem attackSystem;
        [SerializeField] private float health;

        private void Start()
        {
            attackSystem = new AttackSystem();
        }

        public void TakeDamage(AttackData attackData)
        {
            attackData.Damageable = this;
            attackSystem.ExecuteAttack(attackData);
            DealDamage(attackData.FinalDamage);
        }

        public void DealDamage(float value)
        {
            health -= value;
        }
    }
}