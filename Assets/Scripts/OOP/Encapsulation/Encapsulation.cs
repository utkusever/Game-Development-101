using UnityEngine;

namespace OOP.Encapsulation
{
    public class Encapsulation : MonoBehaviour
    {
        // Prevents direct modification of data/object from outside the class.
        // Defines how data can be accessed and modified.
        private void Start()
        {
            Name name = new Name();

            name.SetName("Utku");
            print(name.GetName());
        }
    }

    public class Name
    {
        private string name;

        // Setter method
        public void SetName(string name)
        {
            this.name = name;
        }

        // Getter method
        public string GetName()
        {
            return name;
        }
    }
}