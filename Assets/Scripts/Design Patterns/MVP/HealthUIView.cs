using TMPro;
using UnityEngine;

namespace Design_Patterns.MVP
{
    public class HealthUIView : MonoBehaviour, IUIHealthPanel
    {
        [SerializeField] private TMP_Text healthText;

        public void UpdateHealthUI(int currentHealth)
        {
            healthText.text = currentHealth.ToString();
        }
    }
//may we find this component later 
    public interface IUIHealthPanel
    {
        void UpdateHealthUI(int currentHealth);
    }
}