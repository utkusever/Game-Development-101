using UnityEngine;

namespace Design_Patterns.Chain_Of_Responsibility
{
    public abstract class StatHandler : IStatHandler
    {
        private IStatHandler nextHandler;

        public void SetNext(IStatHandler next)
        {
            nextHandler = next;
        }

        public virtual void Handle(ref float damageValue)
        {
            nextHandler?.Handle(ref damageValue);
        }
    }

    public class UpgradeStatHandler : StatHandler
    {
        private float dmgUpgradeStat = 5f;

        public override void Handle(ref float damageValue)
        {
            damageValue += dmgUpgradeStat;
            Debug.Log("Upgrade Damage Stat Applied Current Damage: " + damageValue);
            base.Handle(ref damageValue);
        }
    }

    public class CharacterStatHandler : StatHandler
    {
        private float characterDamageStat = 10f;

        public override void Handle(ref float damageValue)
        {
            damageValue += characterDamageStat;
            Debug.Log("Character Damage Stat Applied Current Damage: " + damageValue);
            base.Handle(ref damageValue);
        }
    }

    public class WeaponStatHandler : StatHandler
    {
        private float weaponDamageStat = 14f;

        public override void Handle(ref float damageValue)
        {
            damageValue += weaponDamageStat;
            Debug.Log("Weapon Damage Stat Applied Current Damage: " + damageValue);
            base.Handle(ref damageValue);
        }
    }
}