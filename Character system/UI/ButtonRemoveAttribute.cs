using Character_system.Character;
using System.Windows.Controls;

namespace Character_system.UI
{
    internal class ButtonRemoveAttribute : Button
    {
        public CharacterAttribute Attribute { get; set; }
        public ButtonRemoveAttribute(CharacterAttribute attribute)
        {
            Attribute = attribute;
            FontSize = 20;
            Width = 20;
            Height = 20;
        }
    }
}
