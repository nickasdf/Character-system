using System;
using System.Linq;
using Character_system.Services;
using Character_system.Character;
using System.Collections.Generic;

namespace Character_system.Handlers
{
    internal class CharacterHandler
    {
        public static bool LoadCharacter(string path)
        {
            try
            {
                Character.Character.character = CharacterIO.ReadFromBinaryFile<Character.Character>(path);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool SaveCharacter(string path)
        {
            try
            {
                if (Character.Character.character == null)
                {
                    throw new Exception("Character is null");
                }
                CharacterIO.WriteToBinaryFile(path, Character.Character.character);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static void AddAttribute(CharacterObject obj, CharacterAttribute attribute)
        {
            obj.attributes.Add(attribute);
        }
        public static void RemoveAttribute(Character.CharacterObject character, int index)
        {
            character.attributes.RemoveAt(index);
        }
        public static void RemoveAttribute(Character.CharacterObject character, string name)
        {
            character.attributes.RemoveAll(x => x.name == name);
        }
        public static bool AddObject(Character.Character character, CharacterObject obj)
        {
            if (character.currentWeight + obj.weight < character.maxCapacity)
            {
                character.items.Add(obj);
                character.currentWeight += obj.weight;
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void RemoveObject(Character.Character character, int index)
        {
            character.items.RemoveAt(index);
        }
        public static void RemoveObject(Character.Character character, CharacterObject obj)
        {
            character.items.Remove(obj);
        }
        public static bool AddObjects(Character.Character character, CharacterObject obj, int number = 1)
        {
            foreach (var i in Enumerable.Range(0, number))
            {
                if (!AddObject(character, obj))
                {
                    return false;
                }
            }
            return true;
        }
        public static void RemoveAllObjects(Character.Character character, string name)
        {
            character.items.RemoveAll(x => x.name == name);
        }

        public static int FindCharacterObjectByName(Character.Character character, string name)
        {
            List<CharacterObject> items = new List<CharacterObject>();
            foreach (var item in character.items)
            {
                items.Add(new CharacterObject(item));
            }
            name = name.ToLower();
            for (int i = 0; i < items.Count;i++)
            {
                items[i].name = items[i].name.ToLower();
                if (items[i].name == name || items[i].name.Contains(name))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
