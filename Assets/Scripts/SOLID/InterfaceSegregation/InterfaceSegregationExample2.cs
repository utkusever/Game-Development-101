using System.Collections.Generic;
using UnityEngine;

namespace SOLID.InterfaceSegregation
{
    public class InterfaceSegregationExample2 : MonoBehaviour
    {
        private void Start()
        {
            IWeapon sword = new Sword();
            IWeapon bow = new Bow();
            List<IWeapon> weapons = new List<IWeapon> { sword, bow };
            List<IReloadable> reloadables = new List<IReloadable> { new Bow() };
            foreach (var weapon in weapons)
            {
                weapon.Attack();
            }

            foreach (var reloadable in reloadables)
            {
                reloadable.Reload();
            }
        }
    }

    public interface IWeapon
    {
        void Attack();
        //void Reload(); what about a sword?
    }

    public interface IReloadable
    {
        void Reload();
    }

    public interface IMeleeWeapon : IWeapon
    {
        void Swing();
    }

    public interface IRangedWeapon : IWeapon, IReloadable
    {
        void Shoot();
    }

    public class Sword : IMeleeWeapon
    {
        public void Attack()
        {
            Swing();
        }

        public void Swing()
        {
            Debug.Log("Swinging the sword!");
        }
    }

    public class Bow : IRangedWeapon
    {
        public void Attack()
        {
            Shoot();
        }

        public void Shoot()
        {
            Debug.Log("Shooting an arrow!");
        }

        public void Reload()
        {
            Debug.Log("Reloading the bow!");
        }
    }
}