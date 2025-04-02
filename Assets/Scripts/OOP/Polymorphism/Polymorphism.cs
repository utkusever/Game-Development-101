using System.Collections.Generic;
using UnityEngine;

public class Polymorphism : MonoBehaviour
{
    // Its kinda like climbing a ladder from bottom to top or from top to bottom, Enemy -> Alien (downcasting) or Alien -> Enemy (upcasting)
    private void Start()
    {
        // Not every Enemy is a Monster.
        // Monster monster = new Enemy();
        Upcasting();
        Downcasting();
        // ReferenceToWrongSubtype();
        EnemyList();
    }

    //Upcasting, daha özel bir türü daha genel bir türdeki değişkene atamak anlamına gelir.
    //Upcasting means assigning a more specific type to a more general type.
    //Upcasting ile temel sınıfın metotlarına ve özelliklerine erişilebilir, ancak türetilmiş sınıfın özel metotlarına erişilemez.
    //With upcasting, you can access the base class methods and properties, but not the special methods of the derived class.

    private void Upcasting()
    {
        // Upcasting narrows methods and attributes 

        Monster monster = new Monster(); // from spesific
        Enemy enemy = monster; // to more general 
        // same ((Enemy)(monster)).Attack();  

        enemy.Attack();
        // enemy.Roar(); Nope u can't, Monster upcasted to Enemy
    }

    //Downcasting, daha genel bir türü daha özel bir türdeki değişkene atamak anlamına gelir.
    //Downcasting means assigning a more general type to a more specific type variable.
    //Downcasting ile türetilmiş sınıfın özel metotlarına erişebilirsin, ancak nesne gerçekten türetilmiş türde değilse bu işlem riskli olabilir.
    //With downcasting, you can access the special methods of the derived class, but it can be risky if the object is not actually of the derived type.

    private void Downcasting()
    {
        // Downcasting extends methods and attributes available to this object.

        Enemy enemy = new Alien(); // upcasting 
        Alien alien = (Alien)enemy; // downcasting from general to spesific     
        //same ((Alien)enemy).Teleport();

        alien.Teleport();
        alien.Attack();
    }


    private void ReferenceToWrongSubtype()
    {
        // Object o = new Animal();
        // Object o = new Enemy();
        // ((Enemy)o).Yell();

        // It is legal to cast a reference to the wrong subtype; 
        // However, this will compile but crash when the program runs.
        // ((Cat)o).Eat();
        // ((Cat)o).Meow();
    }

    private void EnemyList()
    {
        List<Enemy> enemies = new List<Enemy>();
        // We can use different subclasses as the same base class.

        enemies.Add(new Alien());
        enemies.Add(new Monster());

        foreach (Enemy enemy in enemies)
        {
            enemy.Attack(); // Monster and Alien uses their own Attack methods.
            // enemy.Teleport();  u can't...
            // enemy.Roar();  u can't...

            if (enemy is Alien)
            {
                // we need to downcast to access its methods
                var alien = (Alien)enemy;
                alien.Teleport();
                // now u can...
            }
        }
    }

    private class Enemy
    {
        public virtual void Attack()
        {
            Debug.Log("Attack!");
        }
    }

    private class Alien : Enemy
    {
        public override void Attack()
        {
            Debug.Log("Shoots a laser!");
        }

        public void Teleport()
        {
            Debug.Log("You can't catch me!");
        }
    }

    private class Monster : Enemy
    {
        public override void Attack()
        {
            Debug.Log("Smashes with brute force!");
        }

        public void Roar()
        {
            Debug.Log("Did u scare?");
        }
    }
}