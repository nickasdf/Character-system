using Character_system.Character;
using System.Windows.Controls;

namespace Character_system.UI
{
    internal class TextBoxObject : TextBox
    {
        public CharacterObject Object { get; set; }
        public bool ShouldRewrite { get; set; }

        public TextBoxObject(CharacterObject @object)
        {
            Object = @object;
            Text = Object.ToString();
            FontSize = 20;
            ShouldRewrite = true;
        }
    }
}
