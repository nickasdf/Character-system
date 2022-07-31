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

        public List<CharacterAttribute> prioratyAttribute;
         
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
               "Max Capacity : " + maxCapacity + "\n" + items ;

        }
        public Character(float maxCapacity = 0, string name = null, List<CharacterObject> items = null)
        {
            this.maxCapacity = maxCapacity;
            this.name = name;
            this.items = items;
            currentWeight = 0;
        }

    }
}
