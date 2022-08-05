using Character_system.Character;
using System.Windows.Controls;

namespace Character_system.UI
{
    internal class TextBlockAttribute : TextBlock
    {
        public CharacterAttribute Attribute { get; set; }
        public bool ShouldRewrite { get; set; }
        public TextBlockAttribute(CharacterAttribute attribute)
        {
            Attribute = attribute;
            Text = Attribute.ToString();
            FontSize = 20;
            ShouldRewrite = false;
        }
    }
}
