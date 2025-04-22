using UnityEngine;

namespace Design_Patterns.Chain_Of_Responsibility
{
    public class StatCalculatorChainSystem
    {
        private readonly IStatHandler statChain;

        public StatCalculatorChainSystem()
        {
            var upgradedStat = new UpgradeStatHandler();
            var characterStat = new CharacterStatHandler();
            var weaponStat = new WeaponStatHandler();
            upgradedStat.SetNext(characterStat);
            characterStat.SetNext(weaponStat);
            statChain = upgradedStat;
        }

        public void CalculateValue(ref float damage)
        {
            statChain.Handle(ref damage);
            Debug.Log("Final Damage after stats applied: " + damage);
        }
    }
}