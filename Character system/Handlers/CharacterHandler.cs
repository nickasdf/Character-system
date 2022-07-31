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


        public string AddObject(Character.Character character, Character.CharacterObject obj, int number = 1)
        {
#pragma warning disable CS0162 // Unreachable code detected
            for (int i = 0; i < number; i++)
            {
                if (character.currentObjectsWeight + obj.weight < character.maxCapacity & number <= 0 )
                {
                    character.items.Add(obj);
                    character.currentObjectsWeight += obj.weight;
                    return "object(s) " + obj.name + " was added successfully  " ;
                }
                else
                {
                    return "was added just " + Convert.ToString(i) + "Objects";
                }
            }
#pragma warning restore CS0162 // Unreachable code detected 
            // просто відключає єбучий warning щоб не засоряв проект 
            return "unexpected error";
        }


        public void AddPrioratyAttribute(Character.Character character, Character.CharacterAttribute prioratyAtribute)
        {
            character.prioratyAtribute.Add(prioratyAtribute);
        }
    }
}
