using UnityEngine;

public class Inheritance : MonoBehaviour
{
    // Allows reuse of common properties and methods without rewriting them.
    // Improves modularity and extensibility
    // Allows the creation of new abstractions based on existing ones

    private void Start()
    {
        Enemy enemy = new Enemy();
        Alien alien = new Alien();
        Monster monster = new Monster();
        enemy.Die();
        alien.Die();
        monster.Die();
    }

    private class Enemy
    {
        public virtual void Die()
        {
            Debug.Log("Are you trying to kill me?");
        }
    }

    private class Alien : Enemy
    {
        public override void Die()
        {
            Debug.Log("I'm an Alien, u can't kill me with those guns!");
        }
    }

    private class Monster : Enemy
    {
        public override void Die()
        {
            base.Die();
            Debug.Log("I'm a Monster, u can't kill me no way!");
        }
    }
}