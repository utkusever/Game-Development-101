using UnityEngine;

namespace Design_Patterns.MVP
{
    public class HealthPresenter : MonoBehaviour
    {
        [SerializeField] private HealthModel healthModel;
        [SerializeField] private HealthUIView healthUIView;

        private void Awake()
        {
            healthModel.OnHealthChanged += currentHealth => healthUIView.UpdateHealthUI(currentHealth);
        }
    }
}