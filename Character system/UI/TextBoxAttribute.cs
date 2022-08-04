using Character_system.Character;
using System.Windows.Controls;

namespace Character_system.UI
{
    internal class TextBoxAttribute : TextBox
    {
        public bool ShouldRewrite { get; set; }
        public CharacterAttribute Attribute { get; set; }
        public TextBoxAttribute(CharacterAttribute attribute)
        {
            Attribute = attribute;
            Text = Attribute.ToString();
            FontSize = 20;
            ShouldRewrite = true;
        }
    }
}
