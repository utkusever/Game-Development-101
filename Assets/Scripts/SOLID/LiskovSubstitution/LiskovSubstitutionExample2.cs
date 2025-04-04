using System;
using System.Collections.Generic;
using UnityEngine;

namespace SOLID.LiskovSubstitution
{
    public class LiskovSubstitutionExample2 : MonoBehaviour
    {
        private void Start()
        {
            Weapon weapon = new Pistol(); // upcasting
            Weapon weapon2 = new Knife(); // upcasting
            List<Weapon> weapons = new List<Weapon> { weapon, weapon2 };
            foreach (var w in weapons)
            {
                w.Attack();
                if (w is FireArm)
                {
                    ((FireArm)w).Reload(); // downcasting
                }
            }
        }
    }
    // Every weapon is not reloadable!
// public abstract class Weapon
// {
//     public abstract void Attack();
//     public abstract void Reload();
// }

    public abstract class Weapon
    {
        public abstract void Attack();
    }

    public abstract class FireArm : Weapon
    {
        public override void Attack()
        {
        }

        public abstract void Reload();
    }

    public class Pistol : FireArm
    {
        public override void Attack()
        {
            Debug.Log("pew pew");
        }

        public override void Reload()
        {
            Debug.Log("pistol reloading");
        }
    }

    public class Knife : Weapon
    {
        public override void Attack()
        {
            Debug.Log("swing");
        }
        // Knife can't reloadable
        // public override void Reload()
        // {
        //     Debug.Log("WHAT????");
        // }
    }
}