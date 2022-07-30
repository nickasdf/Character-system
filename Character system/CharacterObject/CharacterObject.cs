using System;
using System.Collections.Generic;

namespace Character_system.Character
{
    [Serializable]
    class CharacterAttribute
    {
        public string name;
        public object value;
        public CharacterAttribute(string name=null, object value=null)
        {
            this.name = name;
            this.value = value;
        }

        public override string ToString()
        {
            return name + ": " + value.ToString();
        }
    }

    [Serializable]
    class CharacterObject
    {
        public string name;
        public string description;
        public float weight;
        public List<CharacterAttribute> attributes;
        public CharacterObject(string name = null, string description = null, float weight = 0, List<CharacterAttribute> attributes = null)
        {
            this.name = name;
            this.description = description;
            this.weight = weight;
            this.attributes = attributes;
        }

        public override string ToString()
        {
            string str =
                 "name: " + name + '\n' +
                "description: " + description + '\n' +
                "weight: " + weight + '\n' + 
                "attributes:" + '\n';
            string attributes = "";
            foreach (var attribute in this.attributes)
            {
                attributes += '\t' + attribute.ToString() + '\n';
            }
            return str + attributes;
        }
    }
}

