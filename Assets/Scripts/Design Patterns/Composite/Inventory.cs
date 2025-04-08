using System.Collections.Generic;
using UnityEngine;

namespace Design_Patterns.Composite
{
    public class Inventory : MonoBehaviour
    {
        private IEquipable equipmentSet = new EquipmentSet(new List<IEquipable>
        {
            new Weapon("Sword"),
            new Armor("Shield")
        });

        private void Start()
        {
            Armor shield = new Armor("Shield");
            equipmentSet.Equip();
            shield.Unequip();
        }

        // Shared Interface
        public interface IEquipable
        {
            void Equip();
            void Unequip();
        }

        // Leaf (Single)
        public class Weapon : IEquipable
        {
            public string name;

            public Weapon(string name)
            {
                this.name = name;
            }

            public void Equip()
            {
                Debug.Log($"{name} equipped.");
            }

            public void Unequip()
            {
                Debug.Log($"{name} unequipped.");
            }
        }

        // Leaf (Single)
        public class Armor : IEquipable
        {
            public string name;

            public Armor(string name)
            {
                this.name = name;
            }

            public void Equip()
            {
                Debug.Log($"{name} equipped.");
            }

            public void Unequip()
            {
                Debug.Log($"{name} unequipped.");
            }
        }

        // Composite (Group)
        public class EquipmentSet : IEquipable
        {
            private readonly List<IEquipable> equipment;

            public EquipmentSet(List<IEquipable> equipables)
            {
                this.equipment = equipables;
            }

            public void Equip()
            {
                foreach (var item in equipment)
                {
                    item.Equip();
                }
            }

            public void Unequip()
            {
                foreach (var item in equipment)
                {
                    item.Unequip();
                }
            }
        }
    }
}