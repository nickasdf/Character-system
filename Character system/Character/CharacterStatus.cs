using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character_system.Character
{
    internal class CharacterStatus
    {
        public List<CharacterAttribute> allAttributes;
        public CharacterStatus()
        {
            this.allAttributes = new List<CharacterAttribute>();
            List<CharacterAttribute> allAttributes = new List<CharacterAttribute>();
            foreach (var item in new List<CharacterObject>(Character.character.items))
                foreach (var attibute in item.attributes)
                    allAttributes.Add(new CharacterAttribute(attibute));
            var names = from attribute in allAttributes group attribute by attribute.name;
            foreach (var name in names)
            {
                if (name.Count() > 1)
                {
                    this.allAttributes.Add(name.ElementAt(0));
                    var list = name.ToList();
                    list.RemoveAt(0);
                    foreach (CharacterAttribute attribute in list)
                        this.allAttributes[this.allAttributes.Count - 1].value += attribute.value;
                }
                else
                    this.allAttributes.Add(name.ElementAt(0));
            }
        }
        public bool Equals(CharacterAttribute attribute1, CharacterAttribute attribute2)
        {
            if (attribute1.name == attribute2.name)
            {
                return true;
            }
            return false;
        }
        /*public void Fillstatus(Character character)
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
                        foreach (var uniqueAttribute in new List<CharacterAttribute>(allAttributes))
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
        }*/
    }
}
