using System;
using System.Collections.Generic;

namespace Character_system.Character
{
    [Serializable]
    internal class Character
    {
        public string name;
        public float maxCapacity;
        public float currentWeight;
        public List<CharacterObject> items;
        public Character(float maxCapacity = 0, string name = null, List<CharacterObject> items = null)
        {
            this.name = name;
            this.maxCapacity = maxCapacity;
            currentWeight = 0;
            this.items = items;
        }
        public Character(Character character)
        {
            name = character.name;
            maxCapacity = character.maxCapacity;
            currentWeight = character.currentWeight;
            items = new List<CharacterObject>(character.items);
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
