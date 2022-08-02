using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character_system.Character
{
    internal class Character
    {
        public string name;
        public float maxCapacity;
        public float currentWeight;
        public List<CharacterAttribute> priorityAttribute;
        public List<CharacterObject> items;
        public Character(float maxCapacity = 0, string name = null, List<CharacterObject> items = null, List<CharacterAttribute> priorityAttribute = null)
        {
            this.name = name;
            this.maxCapacity = maxCapacity;
            currentWeight = 0;
            this.items = items;
            this.priorityAttribute = priorityAttribute;
        }
        public override string ToString()
        {
            string items = "";
            foreach (var item in this.items)
            {
                items += item.ToString();
            }
            return
                "Name : " + name + "\n" +
                "Max Capacity : " + maxCapacity + "\n" +
                "CurrentWeight: " + currentWeight + "\n" + 
                items;
        }
        public static Character character { get; set; }
    }
}
