using UnityEngine;

namespace Design_Patterns.Chain_Of_Responsibility
{
    public class Character : MonoBehaviour
    {
        private float baseDmg = 1f;

        private void Start()
        {
            var statCalc = new StatCalculatorChainSystem();
            statCalc.CalculateValue(ref baseDmg);
        }
    }
}