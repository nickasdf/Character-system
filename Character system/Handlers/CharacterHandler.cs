using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character_system.Handlers
{
    internal class CharacterHandler
    {
        public void AddAttribute(Character.CharacterObject obj, Character.CharacterAttribute attribute)
        {
            obj.attributes.Add(attribute);
        }


        public bool AddObject(Character.Character character, Character.CharacterObject obj, int number = 1)
        {
            foreach (var i in Enumerable.Range(0, number))
            {
                if (character.currentWeight + obj.weight < character.maxCapacity)
                {
                    character.items.Add(obj);
                    character.currentWeight += obj.weight;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }


        public void AddPrioratyAttribute(Character.Character character, Character.CharacterAttribute prioratyAtribute)
        {
            character.prioratyAttribute.Add(prioratyAtribute);
        }
    }
}
