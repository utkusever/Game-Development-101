using UnityEngine;

namespace SOLID.DependencyInversion
{
    public class DependencyInversion : MonoBehaviour
    {
        // High-level modules(classes) should not depend on low-level modules. Both should depend on abstractions.
        private void Start()
        {
            Pistol pistol = new Pistol();
            Knife knife = new Knife();
            
            Player player = new Player();

            player.SetWeapon(pistol);
            player.EquipWeapon();
            player.PerformAttack();

            player.UnEquipWeapon();
            player.SetWeapon(knife);
            player.EquipWeapon();
            player.PerformAttack();
        }
    }

    public interface IWeapon
    {
        void Attack();
    }

    public interface IReloadable
    {
        void Reload();
    }

    public interface IEquippable
    {
        void Equip();
        void UnEquip();
    }

    public interface IFireArm : IWeapon, IReloadable, IEquippable
    {
    }

    public interface IMeleeWeapon : IWeapon, IEquippable
    {
    }

    public class Pistol : IFireArm
    {
        public void Attack()
        {
            Debug.Log("Pistol shooting");
            Reload();
        }

        public void Reload()
        {
            Debug.Log("Pistol reloading");
        }

        public void Equip()
        {
            Debug.Log("Pistol equipped on right hand");
        }

        public void UnEquip()
        {
            Debug.Log("Pistol unequipped");
        }
    }

    public class Knife : IMeleeWeapon
    {
        public void Attack()
        {
            Debug.Log("knifed!");
        }

        public void Equip()
        {
            Debug.Log("Knife has equipped on left hand");
        }

        public void UnEquip()
        {
            Debug.Log("Knife unequipped");
        }
    }

    // Player doesnt even know current his weapon type knife, ar, launcher etc.
    public class Player
    {
        private IWeapon currentWeapon;

        public void SetWeapon(IWeapon weapon)
        {
            currentWeapon = weapon;
        }

        public void EquipWeapon()
        {
            if (currentWeapon is IEquippable)
            {
                ((IEquippable)currentWeapon)?.Equip();
            }
        }

        public void UnEquipWeapon()
        {
            if (currentWeapon is IEquippable)
            {
                ((IEquippable)currentWeapon)?.UnEquip();
            }
        }

        public void PerformAttack()
        {
            Debug.Log("Started to Attack!");
            currentWeapon?.Attack();
        }
    }
}