using System.Collections.Generic;

namespace Character_system
{
    struct Attribute
    {
        string name;
        object value;
    }

    class CharacterObject
    {
        public string name;
        public string description;
        public float weight;
        public List<Attribute> attributes;
    }
}

