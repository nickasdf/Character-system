using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character_system
{
    internal class CharacterStatus
    {
        List<Character.CharacterAttribute> allAttributes;

        public CharacterStatus()
        {
            allAttributes = new List<Character.CharacterAttribute>();
        }
        public bool Equals(Character.CharacterAttribute attribute1, Character.CharacterAttribute attribute2)
        {
            if (attribute1.name == attribute2.name)
            {
                return true;
            }
            return false;
        }
        public void Fillstatus(Character.Character character)
        {
            allAttributes.Clear();
            foreach (var item in character.items)
            {
                foreach (var attribute in item.attributes)
                {
                    if (allAttributes.Count == 0)
                    {
                        allAttributes.Add(attribute);
                    }
                    else
                    {
                        foreach (var uniqueAttribute in allAttributes)
                        {
                            if (Equals(uniqueAttribute, attribute))
                            {
                                uniqueAttribute.value += attribute.value;
                            }
                            else
                            {
                                allAttributes.Add(attribute);
                            }
                        }
                    }
                }
            }
        }
    }
}
