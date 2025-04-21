using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Design_Patterns.Chain_Of_Responsibility
{
    public abstract class Attack
    {
        public int BaseDamage { get; set; }
    }

    public class FireAttack : Attack
    {
        public int BurnDamage { get; set; } = 10;
    }

    public class IceAttack : Attack
    {
        public float FreezeDuration { get; set; } = 2f; // sec.
    }

    public class PoisonAttack : ContinuousAttack
    {
        public int PoisonDamageOverTime { get; set; } = 5;
    }

    public class ContinuousAttack : Attack
    {
        public int Duration { get; set; } = 5;
    }

    public class BleedingAttack : ContinuousAttack
    {
        public float BleedDamage => BaseDamage / 2f;
    }

    public class AttackData
    {
        public Attack Attack { get; set; }

        public int FinalDamage { get; set; }

        public List<string> StatusEffects { get; private set; } = new List<string>();

        public CharacterData AttackerData { get; set; }
        public IDamageable Damageable;
    }

    public interface IDamageable
    {
        void TakeDamage(AttackData attackData);
        void DealDamage(float value);
    }

    public class CharacterData
    {
        public float CriticChance { get; set; } = 50;
    }

    public interface IAttackHandler
    {
        void SetNext(IAttackHandler next);
        void Handle(AttackData attackData);
    }

    public class FireAttackHandler : IAttackHandler
    {
        private IAttackHandler nextHandler;

        public void SetNext(IAttackHandler next)
        {
            nextHandler = next;
        }

        public void Handle(AttackData attackData)
        {
            if (attackData.Attack is FireAttack fireAttack)
            {
                attackData.FinalDamage += fireAttack.BurnDamage;
                attackData.StatusEffects.Add("Burn");
                Debug.Log("Fire attack handled. BurnDamage applied.");
            }

            nextHandler?.Handle(attackData);
        }
    }

    public class PoisonAttackHandler : IAttackHandler
    {
        private IAttackHandler nextHandler;

        public void SetNext(IAttackHandler next)
        {
            nextHandler = next;
        }

        public void Handle(AttackData attackData)
        {
            if (attackData.Attack is PoisonAttack poisonAttack)
            {
                attackData.FinalDamage += poisonAttack.PoisonDamageOverTime;
                attackData.StatusEffects.Add("Poisoned");
                Debug.Log("Poison attack handled. Poison applied.");
            }

            nextHandler?.Handle(attackData);
        }
    }

    public class IceAttackHandler : IAttackHandler
    {
        private IAttackHandler nextHandler;

        public void SetNext(IAttackHandler next)
        {
            nextHandler = next;
        }

        public void Handle(AttackData attackData)
        {
            if (attackData.Attack is IceAttack iceAttack)
            {
                attackData.StatusEffects.Add($"Frozen for {iceAttack.FreezeDuration} seconds");
                Debug.Log($"Ice attack handled. Freeze for {iceAttack.FreezeDuration}s.");
            }

            nextHandler?.Handle(attackData);
        }
    }

    public class CriticAttackHandler : IAttackHandler
    {
        private IAttackHandler nextHandler;

        public void SetNext(IAttackHandler next)
        {
            nextHandler = next;
        }

        public void Handle(AttackData attackData)
        {
            if (attackData.AttackerData.CriticChance >= Random.Range(0, 100))
            {
                attackData.FinalDamage *= 2;
                Debug.Log($"Critic attack handled");
            }

            nextHandler?.Handle(attackData);
        }
    }

    public class BleedingAttackHandler : IAttackHandler
    {
        private IAttackHandler nextHandler;

        public void SetNext(IAttackHandler next)
        {
            nextHandler = next;
        }

        public void Handle(AttackData attackData)
        {
            if (attackData.Attack is BleedingAttack bleedingAttack)
            {
                for (int i = 0; i < bleedingAttack.Duration; i++)
                {
                    attackData.Damageable.DealDamage(bleedingAttack.BleedDamage);
                    Debug.Log($"Bleed attack handled");
                }
            }

            nextHandler?.Handle(attackData);
        }
    }

    public class AttackSystem
    {
        private IAttackHandler attackChain;

        public AttackSystem()
        {
            var critic = new CriticAttackHandler();
            var fire = new FireAttackHandler();
            var ice = new IceAttackHandler();
            var poison = new PoisonAttackHandler();
            var bleed = new BleedingAttackHandler();
            critic.SetNext(fire);
            fire.SetNext(ice);
            ice.SetNext(poison);
            poison.SetNext(bleed);
            attackChain = critic;
        }

        public void ExecuteAttack(AttackData attackData)
        {
            attackChain.Handle(attackData);

            Debug.Log($"Final Damage: {attackData.FinalDamage}");
            Debug.Log($"Status Effects: {string.Join(", ", attackData.StatusEffects)}");
        }
    }
}