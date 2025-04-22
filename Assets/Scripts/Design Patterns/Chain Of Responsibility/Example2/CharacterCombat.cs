using System;
using UnityEngine;

namespace Design_Patterns.Chain_Of_Responsibility
{
    public class CharacterCombat : MonoBehaviour
    {
        [SerializeField] private Health health;
        public AttackData attackData;

        private void Start()
        {
            var myData = new CharacterData
            {
                CriticChance = 50
            };
            var attackSystem = new AttackSystem();

            var fireAttack = new FireAttack
            {
                BaseDamage = 10,
                BurnDamage = 5
            };
            var iceAttack = new IceAttack()
            {
                BaseDamage = 10,
            };
            var bleedingEffect = new BleedingAttack()
            {
                BaseDamage = 10,
                Duration = 5,
            };
            attackData = new AttackData
            {
                Attack = bleedingEffect,
                FinalDamage = bleedingEffect.BaseDamage,
                AttackerData = myData,
            };
            float baseDmg = 0;
            var statCalc = new StatCalculatorChainSystem();
            statCalc.CalculateValue(ref baseDmg);
        }

        // private void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.Space))
        //     {
        //         health.GetComponent<IDamageable>().TakeDamage(attackData);
        //     }
        // }
    }
}