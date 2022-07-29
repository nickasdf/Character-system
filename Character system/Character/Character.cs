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
        public string name;
        public List<CharacterObject> items;



        public Character(float weight, string name)
        {
            this.maxCapacity = weight;
            this.name = name;
        }
            
    }
}
