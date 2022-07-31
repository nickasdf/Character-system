using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character_system.Character
{
    internal class Character
    {

        public float maxCapacity;
        public float currentWeight;
        public List<CharacterAttribute> priorityAttribute;
        public string name;
        public List<CharacterObject> items;

        public override string ToString()
        {
            string items = "";
            foreach (var item in this.items)
            {
                items += item.ToString();
            }
            return "Name : " + name + "\n" +
               "Max Capacity : " + maxCapacity + "\n" + items;
        }
        public Character(float maxCapacity = 0, string name = null, List<CharacterObject> items = null, List<CharacterAttribute> priorityAttribute = null)
        {
            this.maxCapacity = maxCapacity;
            this.name = name;
            this.items = items;
            this.priorityAttribute = priorityAttribute;
            currentWeight = 0;
        }
        public static Character character { get; set; }
    }
}
