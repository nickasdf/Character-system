using Character_system.Character;
using System.Windows.Controls;

namespace Character_system.UI
{
    internal class ButtonRemoveObject : Button
    {
        public CharacterObject Object { get; set; }
        public ButtonRemoveObject(CharacterObject @object)
        {
            Object = @object;
            FontSize = 20;
            Width = 20;
            Height = 20;
        }
    }
}
