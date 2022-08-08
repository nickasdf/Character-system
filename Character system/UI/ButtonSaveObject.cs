using Character_system.Character;
using System.Windows.Controls;

namespace Character_system.UI
{
    internal class ButtonSaveObject : Button
    {
        public CharacterObject Object { get; set; }
        public TextBoxObject TextBoxObject { get; set; }
        public ButtonSaveObject(CharacterObject @object, TextBoxObject textBoxObject)
        {
            Object = @object;
            TextBoxObject = textBoxObject;
            Width = 20;
            Height = 20;
        }
    }
}
