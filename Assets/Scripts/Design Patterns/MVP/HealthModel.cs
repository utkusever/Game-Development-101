using System;
using UnityEngine;

namespace Design_Patterns.MVP
{
    public class HealthModel : MonoBehaviour
    {
        public event Action<int> OnHealthChanged;
        [SerializeField] private int maxHealth;
        private int currentHealth;

        private void Start()
        {
            ResetHealth();
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            TriggerHealthAction();
        }

        private void ResetHealth()
        {
            currentHealth = maxHealth;
            TriggerHealthAction();
        }

        private void TriggerHealthAction()
        {
            OnHealthChanged?.Invoke(currentHealth);
        }
    }
}